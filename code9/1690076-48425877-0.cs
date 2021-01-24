    public class ShoppingCartController : BaseController
    {
        [HttpPut("api/ShoppingCart/UpdateShoppingCartItem")]
        public IActionResult UpdateShoppingCartItem(long id)
        {
    
            return new NoContentResult();
        }
     }
