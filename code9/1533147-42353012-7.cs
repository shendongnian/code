    public class MyController: Controller
    {
        private readonly IMyService myService;
        public MyController(IMyService myService)
        {
            this.myService = myService;
        }
        public ViewResult Index()
        {
            var instruments = this.myService.GetInstruments();
            return View(instruments);
        }
    }
