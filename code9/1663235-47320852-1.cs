    public class HomeController : BaseController 
    {
       public ActionResult Die()
       {
          throw new Exception("Bad code!");
       }
    }
    public class ProductsController : BaseController 
    {
       public ActionResult Index()
       {
           var arr =new int[2];
           var thisShouldCrash = arr[10];
           return View();
       }
    }
