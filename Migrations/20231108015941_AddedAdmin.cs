using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[] { 4, "admin@gmail.com", "admin", "admin", "23738F175522FC74DAE4DD60C47A64CE984114CF2ADED4D49C7BBB04D44C422088DDA3FFC73728D4C7C91B220D05DE2F470ABA7F4E23B97B130341E2D088ED57", "BE17DF9CFF5CB2ABC159490EB2C62FD062D73C63CA467329ACD7EBF6A280D42F5E53B69664A9450FF250B6793A14CCEA58EAA34B0A639A7928C8077B7A653211", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
