    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = GetUserCultureSomehow();
            var cultureInfo = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            base.OnActionExecuting(filterContext);
        }
    }
