    public class CustomController : Controller {
        protected override RedirectResult Redirect(string url) {
            if (Session["replacedVariable"] == null) {
                return base.Redirect(url);
            }
            string replaceUrl = url.Replace("/" + Session["replacedVariable"], "/originalVariable");
            return base.Redirect(replaceUrl);
        }
    }
