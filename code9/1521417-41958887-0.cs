    public class OutputFormatActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var actionResult = context.Result as ObjectResult;
            if (actionResult == null) return;
            var paramObj = context.HttpContext.Request.Query["prettify"];
            var isPrettify = string.IsNullOrEmpty(paramObj) || bool.Parse(paramObj);
            if (!isPrettify) return;
            
            var settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            actionResult.Formatters.Add(new JsonOutputFormatter(settings, ArrayPool<char>.Shared));
        }
    }
