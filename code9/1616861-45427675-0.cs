    public class PatientsController : Controller
    {
       public ISomeRepository _repo;
       public PatientsController(ISomeRepository repo) 
       { 
          _repo = repo;
       }        
       public ActionResult Index()
       {
          // use _repo here
          return View();
       }
    }
