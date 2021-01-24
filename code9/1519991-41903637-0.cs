    abstract class MyBaseController : Controller
    {
     protected void myMethod()
     {
      // you have access to Request here
     }
    }
    
    public class MyController : MyBaseController
    {
        public IHttpActionResult GetStuff() 
        {
           // do stuff
           base.myMethod();
           return Ok();
        }
    }
