using Microsoft.AspNetCore.Mvc;

namespace RateLimit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(new { Id = 1, Category = "Kırtasiye" });
        }
    }
}
