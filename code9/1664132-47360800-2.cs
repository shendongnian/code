    public class HomeController
    { 
        private readonly IIndex<String, IFilter> _filters;
        public HomeController(IIndex<String, IFilter> filters)
        {
            this._filters = filters; 
        }
        public ActionResult Index()
        {
            var bikeFilter = this._filters["Bike"];
            // ...
        }
    }
 
