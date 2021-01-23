    public class UsageController : BaseController {
        public string MethodToTest() {
           if (DoStuff())
              {return "yes";}
           return "no";
        }
    }
