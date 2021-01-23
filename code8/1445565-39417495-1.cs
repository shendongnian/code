    public class IntegrationController : Controller
    {
        [HttpPost]
        public ActionResult Index([FromBody] DataModel model)
        {
            Console.Write("The value is" + model.v);
            return View();
        }
    }
