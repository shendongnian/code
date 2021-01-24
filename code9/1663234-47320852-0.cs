    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
           // to do : Log the exception (filterContext.Exception)
           // and redirect / return error view
            filterContext.ExceptionHandled = true;
            // If the exception occurred in an ajax call. Send a json response back
            // (you need to parse this and display to user as needed at client side)
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"]
                                                              =="XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { Error = true, Message = filterContext.Exception.Message }
                };
                filterContext.HttpContext.Response.StatusCode = 500; // Set as needed
            }
            else
            {
                filterContext.Result = new ViewResult { ViewName = "Error.cshtml" }; 
                //Assuming the view exists in the "~/Views/Shared" folder
            }
        }
    }
