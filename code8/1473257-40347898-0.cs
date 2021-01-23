    [RoutePrefix("api/foo/users")
    public class ControllerOne : ApiController
    {
       [HttpGet]
       [Route("{someVariable}")]
       public string Bar(int someVariable){return "FooBar";}
    }
    
    [RoutePrefix("api/foo/users/movies")
    public class ControllerThree : ApiController
    {
       [HttpGet]
       [Route("")]
       public void Foo(){}
    }
