        public class ActionLogFilter : IActionFilter
    {
        // some dependencies
        private DateTime traceStart;
        private readonly Stopwatch stopwatch;
        public ActionLogFilter(// some dependencies)
        {
            this.stopwatch = new Stopwatch();
        }
        
        // here the action starts executing
        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.traceStart = DateTime.UtcNow;
            this.stopwatch.Start();
        }
        
        // here the action is executed
        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.stopwatch.Stop();
            var traceEnd = this.traceStart
                           .AddMilliseconds(this.stopwatch.ElapsedMilliseconds);
            // do something, persist it somewhere if necessary
        }
    }
