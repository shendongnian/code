    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
       [HttpPut("Buy")]      // Matches PUT 'api/Products/Buy'
       [HttpPost("Checkout")] // Matches POST 'api/Products/Checkout'
       public IActionResult Buy()
    }
