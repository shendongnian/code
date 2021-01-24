    public class SuperModel
    {
        public string OperationNo { get; set; }
    
    }
    //Create an edmx to your table
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index2003(SuperModel sm, FormCollection formCollection)
        {
            var theId = formCollection.Keys[0];
            return View();
        }
        public ActionResult Index2003()
        {
            SuperModel sm = new SuperModel { OperationNo = "op1" };
            return View(sm);
        }
