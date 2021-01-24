    public class ProductsIdExternalController : Controller
    {
        // This is the wrapper class
        readonly EbayClient _ebay;
    
        public ProductsIdExternalController(EbayClient ebay)
        {
            _ebay = ebay;
        }
    
        [HttpGet]
        public async Task<IActionResult> Index(string itemId)
        {
            var item = await _ebay.GetItemAsync(itemId);
    
            // Use the item however you want.
            // Make sure to handle errors in case the item ID doesn't exist.
        }
    }
