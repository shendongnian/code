    public class SomeService
    {
     public void DoSomeLogic()
     { 
     }
    }
    
    public class FirstController : ApiController
    {
     public IHttpActionResult SomeAction()
     {
       new SomeService().DoSomeLogic();
     }
    }
    
    public class SecondController : ApiController
    {
     public IHttpActionResult SomeOtherAction()
     {
       new SomeService().DoSomeLogic();
     }
    }
