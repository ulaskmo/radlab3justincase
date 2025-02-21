using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProductModel
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public static bool InProduction { get; set; } = false; // Fixed naming convention

        public ProductDBContext() { } // Parameterless constructor for EF Core Migrations

        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myconnectionstring = "Data Source=../ProductCoreDB-2025.db";

            optionsBuilder.UseSqlite(myconnectionstring)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!InProduction)
            {
                Product[] products = DBHelper.Get<Product>(@"../ProductModel/Products.csv").ToArray();
                modelBuilder.Entity<Product>().HasData(products);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}