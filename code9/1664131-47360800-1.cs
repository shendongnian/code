    public class HomeController
    { 
        private readonly IFilterFactory _filters;
        public HomeController(IFilterFactory filters)
        {
            this._filters = filters; 
        }
        public ActionResult Index()
        {
            var bikeFilter = this._filters.Get<IBikeFilter>();
            // ...
        }
    }
