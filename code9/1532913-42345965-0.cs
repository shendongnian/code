    public class Startup
    {
        public static bool IsSessionAvailable { get; set; }
        //...
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            IsSessionAvailable = false; // session not available
        //...
