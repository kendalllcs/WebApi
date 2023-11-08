using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using PizzaStore.Data;
using PizzaStore.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzaStoreDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PizzaStoreDbContext") ?? throw new InvalidOperationException("Connection string 'PizzaStoreDbContext' not found.")));

// Add services to the container.
builder.Services.AddSingleton<PasswordManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var pwdMgr = new PasswordManager();
var results = pwdMgr.HashPassword("admin");
Console.WriteLine("Hash below...");
Console.WriteLine(results.hashString);
Console.WriteLine("Salt below...");
Console.WriteLine(results.saltString);
Console.WriteLine();

builder.Services.AddCors( policy => 
{
        policy.AddPolicy("pizzastore-allowall", config => 
        {
            config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

#region JWT Validation
/*******************************************
 *  Start JWT Security Configuration
 *  ****************************************/
var secret = "MyVerySuperSecureSecretSharedKey";
var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
var issuer = "http://www.ecu.edu";
var audience = "http://www.ecu.edu";

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.ClaimsIssuer = issuer;
    options.MapInboundClaims = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = secretKey,

        ValidateIssuer = true,
        ValidIssuer = issuer,

        ValidateAudience = true,
        ValidAudience = audience,

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            return Task.CompletedTask;

            // ToDo: can check for different kinds of failures
        }
    };
});

/*****************************************
 *  End JWT Security Configuration
 *  **************************************/
#endregion

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("rol", "Admin"));
    options.AddPolicy("ManagerOnly", policy => policy.RequireClaim("rol", "Manager", "Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("rol", "User", "Manager", "Admin"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("pizzastore-allowall");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();