    public class MyActionFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ViewResult)
                context.Controller.ViewBag.Foo = "Bar";
            else
                // do other stuff
        }
    
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
