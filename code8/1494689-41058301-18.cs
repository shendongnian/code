    public class TestController : Controller
    {
         private readonly IMyService _myService;
    
          public TestController(IMyService serv)
          {
               _myService = serv;
          }
    
          public IActionResult Test()
          {
              return _myService.MyMethod(); // No need to instanciate your service here
          }
    }
