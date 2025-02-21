using Microsoft.AspNetCore.Mvc;
using ClassS00219971.Data;
using ClassS00219971.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductWebAPI2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }

        // ✅ GET All Customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        // ✅ GET a Specific Customer by ID
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound(new { Message = "Customer not found" });
            }
            return Ok(customer);
        }
    }
}