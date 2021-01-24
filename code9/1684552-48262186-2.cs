           protected override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (filterContext.ActionDescriptor.ActionName=="YourWebAPIName")
                {
                    filterContext.HttpContext.Response.AddHeader("Set-Cookie","CookieName=CookieValue");           
                }
            //You can replace the former if with a more general one like checking:
            //filterContext.Result.GetType() and see if it is of the type JsonResult
           
                base.OnActionExecuted(filterContext);
            }
