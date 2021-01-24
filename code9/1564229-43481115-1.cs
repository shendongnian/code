    public class CarController : Controller
    {
        List<Category> lstCat = new List<Category>()
        {
            new Category() { CategoryID = 1, CategoryName = "Toyota" },
            new Category() { CategoryID = 2, CategoryName = "Honda" },
            new Category() { CategoryID = 3, CategoryName = "Chevy" }
        };
    
        List<Product> lstProd = new List<Product>()
        {
            new Product() { ProductID = 1, ProductName = "camry", CategoryID = 1 },
            new Product() { ProductID = 2, ProductName = "rav4", CategoryID = 1 },
            new Product() { ProductID = 3, ProductName = "accord", CategoryID = 1 },
            new Product() { ProductID = 4, ProductName = "civic", CategoryID = 2 },
            new Product() { ProductID = 5, ProductName = "fit", CategoryID = 2 },
            new Product() { ProductID = 6, ProductName = "vue", CategoryID = 2 },
            new Product() { ProductID = 7, ProductName = "malibu", CategoryID = 3 },
            new Product() { ProductID = 8, ProductName = "impala", CategoryID = 3 },
            new Product() { ProductID = 9, ProductName = "iroc", CategoryID = 3 }
        };
    
        public ActionResult GetCategories()
        {
            return Json(lstCat, JsonRequestBehavior.AllowGet);
           
        }
    
        public ActionResult GetProducts(int intCatID)
        {
            var products = lstProd.Where(p => p.CategoryID == intCatID);
            return Json(products, JsonRequestBehavior.AllowGet);
    
        }
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(string category ,string product)
        {
    
    
            ViewBag.x ="Product"+ product;
            ViewBag.y = "catego" + category;
            return View();
        }
    }
