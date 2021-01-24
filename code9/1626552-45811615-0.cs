    public class SomeMsgAttribute : FilterAttribute, IResultFilter
    {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
            }
    
            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.Controller.ViewBag.Msg= "Hello";
            }
    }
