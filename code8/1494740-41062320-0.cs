    using Owin;
    using System;
    
    namespace OwinTest
    {
        public class Startup
        {
            public static void Configuration(IAppBuilder app)
            {
                app.Use(async (ctx, next) =>
                {
                    await ctx.Response.WriteAsync(DateTime.Now.ToString() + " My First OWIN App");
                });
            }
        }
    }
