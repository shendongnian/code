    using System.Web.Mvc;
    using Umbraco.Web.Mvc;
    
    public class HomePageController : SurfaceController
    {
        public ActionResult HomePage()
        {
            return View();
        }
    }
