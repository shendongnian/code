    public class HomeController : Controller
        {
    
            public ActionResult GetResult()
            {
                MyApp.DataController dataController = new MyApp.DataController();
                var data = dataController.Post("arguments");
    
                return View(data);
            }
        }
 
         
