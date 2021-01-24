    public class MyController
        {
          private readonly IMyService _myService;
          public MyController(IMyService myService)
          {
            _myService=myService;
          }
        }
