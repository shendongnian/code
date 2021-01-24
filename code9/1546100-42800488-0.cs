    public class MySpecialLoginController:Controller
    {
        public ActionResult Index(string returnUrl)
        {
            if(returnUrl.EndsWith("/foo")) //dirty. you could do better...
            {
                return RedirectToAction("signin","f");
            }
            //etc
        }
    }
