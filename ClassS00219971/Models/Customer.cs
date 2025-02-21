namespace ClassS00219971.Models;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }

    public decimal CreditRating { get; set; }
}

