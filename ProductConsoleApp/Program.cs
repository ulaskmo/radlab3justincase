using System;
using System.Linq;
using ClassS00219971.Data;
using ClassS00219971.Models;

class Program
{
    static void Main()
    {
        using var context = new CustomerDbContext();

        // List all customers
        var customers = context.Customers.ToList();
        Console.WriteLine("All Customers:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Id}: {customer.Name}, {customer.Address}, Credit: €{customer.CreditRating}");
        }

        // Customers with Credit Rating > 400
        var highCreditCustomers = context.Customers.Where(c => c.CreditRating > 400).ToList();
        Console.WriteLine("\nCustomers with Credit Rating > 400:");
        foreach (var customer in highCreditCustomers)
        {
            Console.WriteLine($"{customer.Name}, Credit: €{customer.CreditRating}");
        }

        // Add new customer
        var maxId = context.Customers.Max(c => c.Id) + 1;
        var newCustomer = new Customer { Id = maxId, Name = "New Customer", Address = "New Address", CreditRating = 1000 };
        context.Customers.Add(newCustomer);
        context.SaveChanges();
        Console.WriteLine("\nNew Customer Added.");
    }
}