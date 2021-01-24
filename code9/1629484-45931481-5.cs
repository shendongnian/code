    public class BaseController : Controller
        {
           
            public BaseController()
            {
                if (string.IsNullOrEmpty(SessionManager.SiteUrl))
                {
                    SessionManager.SiteUrl = ConfigurationManager.AppSettings["SiteUrl"].ToString();
                }
            }
    
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
                if (SessionManager.UserId == -1)
                {
                    switch (filterContext.ActionDescriptor.ActionName.ToLower().Trim())
                    {
                        case "addeditcontact":
                           ViewBag.hdnPopupLogout = "0";
                           return;
                        default:
                            filterContext.Result = new   RedirectResult(Url.Action("Login", "Home"));
                            break;
                    }
                }
            }
    }
