    public class ProductController : Controller
    {
        private IProductRepository repository;
    
        public ProductController(IProductRepository productRepository) {
            this.repository = productRepository;
        }
    
        public ViewResult List() {
            return View(repository.Products);
        }
    }
