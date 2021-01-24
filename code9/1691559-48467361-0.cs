    [Route("[controller]")]
       public class HomeController : Controller
       {
          [Route("")]     // Matches 'Home'
          [Route("Index")] // Matches 'Home/Index'
          public IActionResult Index(){}
    
          [Route("Error")] // Matches 'Home/Error'
          public IActionResult Error(){}
    
     }
