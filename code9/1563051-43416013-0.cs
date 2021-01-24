	[Authorize (Users="admin@wwu.edu")]
    public class RetailController : Controller
    {
	
		 private readonly RetailStoreEntities1 db;
        public RetailController()
        {
            db = new RetailStoreEntities1();
        }
		
        // GET: Retail
        [AllowAnonymous]
        public ActionResult Index()
        {             
                string sql = "Select * from Product order by newid()";
                List<Product> productList = db.Product.SqlQuery(sql).ToList();
                return View();
        }
    }
