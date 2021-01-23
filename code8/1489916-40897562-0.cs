    namespace OldApiService{
    
        public static class WebApiConfig {
            public static void Register(HttpConfiguration config) {
                config.config.MapHttpAttributeRoutes();        
            }
        }
    
       [RoutePrefix("api/old/greeting")]
       public class GreetingController: ApiController{
           [Route("")]
           public string Get(){ return "hello from old api"; }
       }
    }
