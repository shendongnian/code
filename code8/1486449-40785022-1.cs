    public class HomeController : Controller
    {
        //
        // GET: /Home/
    
        public ActionResult Index()
        {
            var item = new List<GroupedSelectListItem> {
        new GroupedSelectListItem() { Value = "volvo", Text = "Volvo", GroupName = "Swedish Cars", GroupKey = "1", Disabled = true },
        new GroupedSelectListItem() { Value = "saab", Text = "Saab",GroupName = "Swedish Cars", GroupKey = "1" },
        new GroupedSelectListItem() { Value = "mercedes", Text = "Mercedes", GroupName = "German Cars", GroupKey = "2" },
        new GroupedSelectListItem() { Value = "audi", Text = "Audi", GroupName = "German Cars", GroupKey = "2",Selected = true }};
            return View(item);
        }
    
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
    
       
            return View();
        }
    
    }
