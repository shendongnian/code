    public class MyStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                // Configure middleware
                // ...
    
                // Call the next configure method
                next(app);
            };
        }
    }
