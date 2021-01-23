    namespace MyApi {
    
        public class Startup { 
            public void Configuration(IAppBuilder appBuilder) {
     
                var config = new HttpConfiguration(); 
    
                //Map attribute routes
    
                OldApiService.WebApiConfig.Register(config);
                NewApiService.WebApiConfig.Register(config);
    
                //convention-based routes
                config.Routes.MapHttpRoute( 
                    name: "DefaultApi", 
                    routeTemplate: "api/{api}/{controller}/{id}", 
                    defaults: new { id = RouteParameter.Optional } 
                ); 
    
                appBuilder.UseWebApi(config); 
            } 
        } 
    
    }
