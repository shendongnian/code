    public class HomeController : Controller
    {
        Repository<User> _repository = new Repository<User>();
        public ActionResult Index()
        {
            vm.Example = _repository.GetAll()
                .Where(x => x.RecordStatusDescription == "1").ToList(); 
            return View("index",vm);
        }
    }
