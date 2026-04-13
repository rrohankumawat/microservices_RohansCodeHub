using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrdersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            var orders = new[]
            {
                new { Id = 1, Product = "Laptop", Quantity = 2 },
                new { Id = 2, Product = "Smartphone", Quantity = 5 },
                new { Id = 3, Product = "Headphones", Quantity = 10 }
            };
            return Ok(orders);
        }
    }
}
