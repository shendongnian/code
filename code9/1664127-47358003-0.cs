    public class HomeController
    { 
        private readonly IComponentContext _components;
        public HomeController(IComponentContext components)
        {
            _components = components; // instead of factory interface
        }
        public ActionResult Index()
        {
            var bikeFilter = _components.Resolve<IBikeFilter>();
            // ...
        }
    }
