        public class HomeController : Controller
    {
        private readonly IDoStuff _doStuff;
        private readonly IHubContext<MyHub> _hub;
        public HomeController(IDoStuff doStuff, IHubContext<MyHub> hub)
        {
            _doStuff = doStuff;
            _hub = hub;
        }
        public async Task<IActionResult> Index()
        {
            var data = _doStuff.GetData();
            await _hub.Clients.All.SendAsync("show_data", data);
            return View();
        }
    }
