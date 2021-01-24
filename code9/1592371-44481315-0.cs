    public class MyController
        {
          private readonly IMyService _myService;
          public MyController(IMyService myervice)
          {
            _myService=myervice;
          }
        }
