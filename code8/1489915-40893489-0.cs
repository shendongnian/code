    namespace OldApiService{
       [RoutePrefix("api/old/greeting")]
       public class GreetingController: ApiController{
           [Route("")]
           public string Get(){ return "hello from old api"; }
       }
    }
    
    namespace NewApiService{
       [RoutePrefix("api/new/greeting")]
       public class GreetingController: ApiController{
           [Route("")]
           public string Get(){ return "hello from new api"; }
       }
    }
