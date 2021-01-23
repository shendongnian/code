    //Validate all 'unsafe' actions except the ones with the ignore attribute
    [AutoValidateAntiforgeryToken]
    public class MyApi: Controller
    {
        [HttpPost]
        public IActionResult DoSomething(){ }
        [HttpPut]
        public IActionResult DoSomethingElse(){ }
        [IgnoreAntiforgeryToken]   
        public IActionResult DoSomethingSafe(){ }
    }
 
    //Validate only explicit actions
    public class ArticlesController: Controller
    {
        public IActionResult Index(){ }
        [ValidateAntiforgeryToken]
        [HttpPost]   
        public IActionResult Create(){ }
    }
