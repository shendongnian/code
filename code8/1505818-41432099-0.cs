    namespace login.Controllers
    {
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController(UserFactory user) {
            userFactory = user;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        [Route("")]
        public IActionResult Register(Home model)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", model);
            }
            PasswordHasher<Home> Hasher = new PasswordHasher<Home>();
            model.Password = Hasher.HashPassword(model, model.Password);
            userFactory.Add(model);
            ViewBag.message = "Success";
            return View();
           }
        }
    } 
