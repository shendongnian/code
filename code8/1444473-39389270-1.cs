    public class TestController : Controller
    {
               [HttpGet]
                public ActionResult Index()
                {
                    return View();
                }
    
    
                [HttpPost]
                public JsonResult Index(string num1, string num2)
                {
                    var num11 = Convert.ToInt32(num1);
                    var num21 = Convert.ToInt32(num2);
                    int result = num11 + num21;
    
                    return Json(result);
                }
    }
