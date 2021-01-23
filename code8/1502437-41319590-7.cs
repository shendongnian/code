    public class HomeController : Controller
    {
        Repository<Example> _repository = new Repository<Example>();
        public ActionResult Index()
        {
            vm.Example = _repository.GetAll()
                .Where(x => x.RecordStatusDescription == "1").ToList(); 
            return View("index",vm);
        }
    }
