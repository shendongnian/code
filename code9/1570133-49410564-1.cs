    public class OtherController : Controller
    {
        [HttpGet]
        public IActionResult Cart()
        {
            return ViewComponent("Cart");
        }
    }
