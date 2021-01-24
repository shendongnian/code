    public abstract class BaseController : Controller
    {
        protected GlobalMessage GlobalMessage;
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                if (GlobalMessage!= null)
                {
                    filterContext.Controller.ViewBag.GlobalMessage = GlobalMessage;
                }
                else
                {
                    GlobalErrorViewModel globalErrorModelView = TempData["GlobalMessage"] as GlobalMessage;
                    if (globalErrorModelView != null)
                    {
                        filterContext.Controller.ViewBag.GlobalErrorViewModel = globalErrorModelView;
                    }
                }
            }
            base.OnActionExecuted(filterContext);
        }
       
    }
