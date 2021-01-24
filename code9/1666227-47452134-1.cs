    public class MyController:Controller
    {
        public ActionResult Index()
        {
           MyModel model = new MyModel();
           model.ImagePath = //here get it from service
           return View(model);
        }
    }
