    internal static class SimpleInjectorMvcActionFilterExtensions
    {
        public static void AddFilter<TActionFilter>(
            this GlobalFilterCollection filters, Container container)
             where TActionFilter : class, IActionFilter
        {
           // Register instance in the container to allow this instance to be
           // diagnosed.
           container.Register<TActionFilter>(Lifestyle.Scoped);
           // Add a proxy to the global filters that resolves the real instance
           filters.Add(new ActionFilterProxy<TActionFilter>(container));
        }
        private sealed class ActionFilterProxy<TActionFilter> : IActionFilter 
            where TActionFilter : class, IActionFilter
        {
           private readonly Container container;
           public ActionFilterProxy(Container container) { this.container = container; }
           public void OnActionExecuting(ActionExecutingContext c)=> Get().OnActionExecuting(c);
           public void OnActionExecuted(ActionExecutedContext c)=> Get().OnActionExecuted(c);
           private TActionFilter Get() => container.GetInstance<TActionFilter>();
        }
    }
