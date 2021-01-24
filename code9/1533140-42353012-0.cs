    public class MyController: Controller
    {
        private readonly IMyService myService;
        public MyController(IMyService myService)
        {
            this.myService = myService;
        }
        ...
    }
