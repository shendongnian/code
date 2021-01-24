     public class RegisterController : Controller
        {
            [HttpGet]
            public ActionResult Register()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult Register(RegistrationModel model)
            {
                //Do something here;
            }
        }
