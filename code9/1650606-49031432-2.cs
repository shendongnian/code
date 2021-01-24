	public class IndexModel : PageModel
    {
        public IMyService _myService;
        public IndexModel(IMyService myService)
        {
            _myService = myService;
        }
        public void OnGet()
        {
			var data = _myService.GetDataOrSomething();
        }
    }
