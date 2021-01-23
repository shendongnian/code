    public class ContentServerController : Controller
    {
        public ActionResult Index()
        {
            var data = new List<string>();
            foreach (string key in Request.QueryString.Keys)
            {
                data.Add("key=[" + (key ?? "--null--") + "], value=[" + Request.QueryString[key] + "]");
            }
            return View(data);
        }
    }
