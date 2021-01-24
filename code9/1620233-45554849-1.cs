    public class ProductsController : Controller {
        private readonly IProductsCSV products;
        public ProductsController(IProductsCSV products) {
            this.products = products;
        }
        public ActionResult Index() {
            List<ProductItem> allProducts = products.GetAllProductsFromCSV();    
            foreach (var product in allProducts) {
                if (string.IsNullOrEmpty(product.ImagePath)) {
                    product.ImagePath = "blank.jpg";
                }
            }    
            return View(allProducts);
        }
    }
