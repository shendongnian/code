    public class MyActionAttribute: Attribute
    {
    }
    ...
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [MyAction]
        public ActionResult DoThis()
        {
            Image img = Image.FromFile("DoThis.png");
            //some other stuff to be done.
            return View();
        }
    
        [MyAction]
        public ActionResult DoThat()
        {
            Image img = Image.FromFile("DoThat.png");
            //some other stuff to be done.
            return View();
        }
    }
