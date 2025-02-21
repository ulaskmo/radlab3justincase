using Microsoft.AspNetCore.Mvc;
using ProductModel;
using ProductWebAPI2025.ViewModel;
using System.Collections.Generic;

namespace ProductWebAPI2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct<Product> _repository;

        public ProductsController(IProduct<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("values/id/{id:int}/name/{name}")]
        public IActionResult Values(int id, string name)
        {
            return Ok(new { id, name });
        }

        [HttpPost("AddProduct/Reorder")]
        public IActionResult AddProductReorderLevel([FromBody] ProductReorderViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(new { Message = "No data" });
            }

            var product = _repository.UpdateReorderLevel(vm.ProductID, vm.ReorderLevel);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found" });
            }

            return Ok(new { Message = "Reorder Level Updated", Product = product });
        }
    }
}