    public class BmwController : Controller
    {
        public BmwController([Dependency("Bmw")ICar car)
        {
        }
    }
