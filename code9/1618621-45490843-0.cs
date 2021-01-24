    public class HomeController : SiteController
    {
        public HomeController(ICategoryHelper categoryHelper) : base(categoryHelper)
        {
        }
    
        public ActionResult Index()
        {
            //Do stuff here
        }    
    }
    
    public class SiteController
    {
        public SiteController(ICategoryHelper categoryHelper)
        {
            viewModel = categoryHelper.GetAllCategories();
        }
    }
    
    public class CategoryHelper : ICategoryHelper
    {
        public IList<string> GetAllCategories()
        {
            //Go off and get the categories from the WCF layer
            return _categories;
        }
    }
    
    public interface ICategoryHelper
    {
        IList<string> GetAllCategories();
    }
