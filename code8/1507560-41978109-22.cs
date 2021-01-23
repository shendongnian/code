    public class Startup {
        public void Configuration(IAppBuilder app) {
            
            app.UseResponseEncrypterMiddleware();
            app.UseRequestLogger();
            //...(after logging middle ware)
            app.UseCommonErrorResponse();
            //... (before auth middle ware)
            //...code removed for brevity
        }
    } 
