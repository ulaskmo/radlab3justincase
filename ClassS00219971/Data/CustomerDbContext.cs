using Microsoft.EntityFrameworkCore;
using ClassS00219971.Models;

namespace ClassS00219971.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        // ✅ Fix: Add a constructor that accepts DbContextOptions
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Patricia McKenna", Address = "8 Johnstown Road, Cork", CreditRating = 200 },
                new Customer { Id = 2, Name = "Helen Bennett", Address = "Garden House Crowther Way, Dublin", CreditRating = 400 },
                new Customer { Id = 3, Name = "Yoshi Tanami", Address = "1900 Oak St., Vancouver", CreditRating = 2000 },
                new Customer { Id = 4, Name = "John Steel", Address = "12 Orchestra Terrace, Dublin 20", CreditRating = 800 },
                new Customer { Id = 5, Name = "Catherine Dewey", Address = "Rue Joseph-Bens 532, Brussels", CreditRating = 600 }
            );
        }
    }
}