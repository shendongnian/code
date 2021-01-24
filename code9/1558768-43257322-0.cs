    public class ClientErrorHandler : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                var response = filterContext.RequestContext.HttpContext.Response;
                response.Write(filterContext.Exception.Message);
                response.ContentType = MediaTypeNames.Text.Plain;
                filterContext.ExceptionHandled = true;
            }
        }
        
        [ClientErrorHandler]
        public class SomeController : Controller
        {
            [HttpPost]
            public ActionResult SomeAction()
            {
                throw new Exception("Error message");
            }
        }
