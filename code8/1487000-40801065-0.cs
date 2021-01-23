    [Route("myurl"]
    public class HomeController : Controller
    {
        public ActionResult Action1()
        {
            if (...)
               {
                  return Action2(); //working fine i will keep my route
               }
            else
               {
                  return DependencyResolver.Current.GetService<OtherController>().Action3();
               }
        }
        public ActionResult Action2()
        {
            return View();
        }
    }
