    public class HomeController : Controller
    {
        private readonly IMyClass myClass;
        public HomeController(IMyClass myClass)
        {
            this.myClass = myClass
        }
    }
   
