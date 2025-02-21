using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClassS00219971.Data;
using ClassS00219971.Models;

class Program
{
    static void Main()
    {
        // ✅ Set up dependency injection for DbContext
        var serviceProvider = new ServiceCollection()
            .AddDbContext<CustomerDbContext>(options =>
                options.UseSqlite("Data Source=../ClassS00219971/CustomerCorDB-S00219971.db"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<CustomerDbContext>();

        // ✅ List all customers
        var customers = context.Customers.ToList();
        Console.WriteLine("All Customers:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Address: {customer.Address}, Credit: {customer.CreditRating}");
        }

        // ✅ Customers with Credit Rating > 400
        var highCreditCustomers = context.Customers.Where(c => c.CreditRating > 400).ToList();
        Console.WriteLine("\nCustomers with Credit Rating > 400:");
        foreach (var customer in highCreditCustomers)
        {
            Console.WriteLine($"Name: {customer.Name}, Credit: {customer.CreditRating}");
        }
    }
}