    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new ViewModel();
            vm.Items = GetItems(); // This retrieves the items from wherever you get them from
    
            return new View(vm);
        }
    }
