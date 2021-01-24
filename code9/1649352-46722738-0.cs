    public interface ICategoryService
    {
        List<Category> LoadCategory();
    }
    public class CategoryService : ICategoryService
    {
        public List<Category> LoadCategory()
        {
            //code here
        }
    }
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        public ProductController()
        {
            _categoryService = <inject dependency here>;
        }
        public ActionResult GetCategory()
        {
            var category = _categoryService.LoadCategory();
        }
    }
    public class SubCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public SubCategoryController()
        {
            _categoryService = <inject dependency here>;
        }
        public ActionResult GetCategory()
        {
            var category = _categoryService.LoadCategory();
        }
    }
