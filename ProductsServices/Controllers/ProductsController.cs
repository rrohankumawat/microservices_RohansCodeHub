using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Laptop", Price = 999.99 },
                new { Id = 2, Name = "Smartphone", Price = 499.99 },
                new { Id = 3, Name = "Headphones", Price = 199.99 }
            };
            return Ok(products);
        }
    }
}
