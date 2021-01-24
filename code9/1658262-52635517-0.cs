    public class CurrentHttpUserProvider : ICurrentUserProvider
    {
        public CurrentHttpUserProvider(IServiceProvider container)
        {
            var httpContext = container.GetService(typeof(HttpContext)); // just returns null if it can't be found...
            if (httpContext != null)
                CurrentUser = ((HttpContext)httpContext).User.Identity.Name;
            else
                CurrentUser = "SYSTEM";
        }
        public string CurrentUser { get; set; }
    }
