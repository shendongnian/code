    public class Shop
    {
        public string ArticleName { get; set; }
        public int ArticleTotalCount { get; set; }
        public List<Package> Package { get; set; }
    }
    public class Package
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
    public class MyModel
    {
        public string ArticleName { get; set; }
        public int CountField { get; set; }
        public string PriceField { get; set; }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult GoIntoMethod(MyModel m) //count field only
        {
            //put a breakpoint here to see you can do whatever you want with the fields
            return Json(new
            {
                targetName = m.PriceField,
                targetCount = m.CountField,
                targetPrice = m.PriceField
            }
             , @"application/json");
        }
        public ActionResult Index28()
        {
            Package p1 = new Package { Count = 1, Price = 2 };
            Package p2 = new Package { Count = 3, Price = 4 };
            Shop s = new Shop { ArticleName = "a1", ArticleTotalCount = 6 };
            s.Package = new List<Package>();
            s.Package.Add(p1);
            s.Package.Add(p2);
            return View(s);
        }
