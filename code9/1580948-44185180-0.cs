    public class CookieController : Controller
    {
        public ActionResult Create()
        {
            HttpCookie cookie = new HttpCookie("Cookie");
            cookie.Value = "Hello Cookie! CreatedOn: " + DateTime.Now.ToShortTimeString();
            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Remove()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }
    }
