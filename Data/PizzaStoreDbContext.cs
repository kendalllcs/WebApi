using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaStore;
using PizzaStore.Entities;

namespace PizzaStore.Data;
    public class PizzaStoreDbContext : DbContext
    {
        public PizzaStoreDbContext (DbContextOptions<PizzaStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<Ingredient> Ingredients { get; set; } = default!;

        public DbSet<Order> Orders { get; set; } = default!;

        public DbSet<LineItem> LineItems { get; set; } = default!;


        public DbSet<User> Users { get; set; } = default!;




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product{ProductId=1, ProductName="Cheese Pizza", Price=9.99f},
                new Product{ProductId=2, ProductName="Peperoni Pizza", Price=10.99f},
                new Product{ProductId=3, ProductName="Supreme Pizza", Price=12.99f},
                new Product{ProductId=4, ProductName="Pinapple Pizza", Price=12.99f},
                new Product{ProductId=5, ProductName="Deluxe Pizza", Price=15.99f},
                new Product{ProductId=6, ProductName="Veggie Pizza", Price=12.99f}
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient{IngredientId=1, IngredientName="Cheese ",},
                new Ingredient{IngredientId=2, IngredientName="Peperoni ",},
                new Ingredient{IngredientId=3, IngredientName="Sausage",},
                new Ingredient{IngredientId=4, IngredientName="Pinapple",},
                new Ingredient{IngredientId=5, IngredientName="Crust",},
                new Ingredient{IngredientId=6, IngredientName="Sauce",}
            );

            modelBuilder.Entity<Role>().HasData(
                new Role{RoleId=1, RoleName="Admin"},
                new Role{RoleId=2, RoleName="User"},
                new Role{RoleId=3, RoleName="Manager"}

            );
            modelBuilder.Entity<User>().HasData(
                new User{UserId=1, Email="kendalllawsoncs@gmail.com", FirstName="Kendall", LastName="Lawson", RoleId=3, PasswordHash="23738F175522FC74DAE4DD60C47A64CE984114CF2ADED4D49C7BBB04D44C422088DDA3FFC73728D4C7C91B220D05DE2F470ABA7F4E23B97B130341E2D088ED57", PasswordSalt="BE17DF9CFF5CB2ABC159490EB2C62FD062D73C63CA467329ACD7EBF6A280D42F5E53B69664A9450FF250B6793A14CCEA58EAA34B0A639A7928C8077B7A653211",},
                new User{UserId=2, Email="notrealatall@gmail.com", FirstName="Bhil", LastName="Khozbee", RoleId=2, PasswordHash="23738F175522FC74DAE4DD60C47A64CE984114CF2ADED4D49C7BBB04D44C422088DDA3FFC73728D4C7C91B220D05DE2F470ABA7F4E23B97B130341E2D088ED57", PasswordSalt="BE17DF9CFF5CB2ABC159490EB2C62FD062D73C63CA467329ACD7EBF6A280D42F5E53B69664A9450FF250B6793A14CCEA58EAA34B0A639A7928C8077B7A653211",},
                new User{UserId=3, Email="kendalldoesnthaveffb@gmail.com", FirstName="Bryhan", LastName="DeeTrek", RoleId=3, PasswordHash="23738F175522FC74DAE4DD60C47A64CE984114CF2ADED4D49C7BBB04D44C422088DDA3FFC73728D4C7C91B220D05DE2F470ABA7F4E23B97B130341E2D088ED57", PasswordSalt="BE17DF9CFF5CB2ABC159490EB2C62FD062D73C63CA467329ACD7EBF6A280D42F5E53B69664A9450FF250B6793A14CCEA58EAA34B0A639A7928C8077B7A653211",},
                new User{UserId=4, Email="admin@gmail.com", FirstName="admin", LastName="admin", RoleId=1, PasswordHash="23738F175522FC74DAE4DD60C47A64CE984114CF2ADED4D49C7BBB04D44C422088DDA3FFC73728D4C7C91B220D05DE2F470ABA7F4E23B97B130341E2D088ED57", PasswordSalt="BE17DF9CFF5CB2ABC159490EB2C62FD062D73C63CA467329ACD7EBF6A280D42F5E53B69664A9450FF250B6793A14CCEA58EAA34B0A639A7928C8077B7A653211",}
            );
        }
}

