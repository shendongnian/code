    public class ProductsController : Controller
    {
       public IActionResult Edit(int id) { ... }
    
       [HttpPost]
       public IActionResult Edit(int id, Product product) { ... }
    }
