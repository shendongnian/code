    public class DataModel
    {
        public string v {get; set;}
    }
    public class IntegrationController : Controller
    {
        [HttpPost]
        public ActionResult Index(DataModel model)
        {
            Console.Write("The value is" + model.v);
            return View();
        }
    }
