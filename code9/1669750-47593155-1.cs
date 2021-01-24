    public class HomeController : Controller
     {  
        private readonly IDbRepository repository;
        public HomeController (IDbRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
           var posts = this.repository.GetPosts();
           //to do   : Return something
        }
    }
