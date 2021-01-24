    // this filter is applied globally during configuration of web application pipeline
    public class LoggingActionFilter : IActionFilter
    {
        // we use private class types as keys for HttpContext.Items dictionary
        // this is better than using strings as the keys, because 
        // it avoids accidental collisions with other code that uses HttpContext.Items
        private class StopwatchItemKey { }
        private class SuppressItemKey { }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // here we save timestamp at the beginning of the request
            // I use Stopwatch because it's handy in this case
            context.HttpContext.Items[typeof(StopwatchItemKey)] = Stopwatch.StartNew();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // check whether SuppressLoggingAttribute was applied to current request
            // we check it here in the end of the request because we don't want to depend
            // on the order in which filters are configured in the pipeline
            if (!context.HttpContext.Items.ContainsKey(typeof(SuppressItemKey)))
            {
                // since SuppressItemKey was not set for the current request, 
                // we can do the logging stuff
                var clock = (Stopwatch) context.HttpContext.Items[typeof(StopwatchItemKey)];
                var elapsedMilliseconds = clock.ElapsedMilliseconds;
                DoMyLoggingStuff(context.HttpContext, elapsedMilliseconds);
            }
        }
        // SuppressLoggingAttribute calls this method to set SuppressItemKey indicator 
        // on the current request. In this way SuppressItemKey remains totally private
        // inside LoggingActionFilter, and no one else can use it against our intention
        public static void Suppress(HttpContext context)
        {
            context.Items[typeof(SuppressItemKey)] = null;
        }
    }
