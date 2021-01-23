    [Route("[controller]")]
    public class UserController : Controller
    {
         
         // < MVC 6 :
         [Route("add")] 
         [HttpPost]    
         public async Task<IActionResult> Create(
                     string name,
                     string state,
                     string zipcode,
                     bool indeFlag,
                     string email)
         {
             // Your code here
         }
         // If you want call this in a simple get query
         [Route("quickadd")] 
         [HttpGet]    
         public async Task<IActionResult> Create(
                     string name,
                     string state,
                     string zipcode,
                     bool indeFlag,
                     string email)
         {
             // Your code here
         }
         // MVC 6 :
         [Route("add")] 
         [HttpPost]    
         public async Task<IActionResult> Create(
                     [FromForm]string name,
                     [FromForm]string state,
                     [FromForm]string zipcode,
                     [FromForm]bool indeFlag,
                     [FromForm]string email)
         {
             // Your code here
         }
         // If you want call this in a simple get query
         [Route("quickadd")] 
         [HttpGet]    
         public async Task<IActionResult> QuickAdd(
                     [FromQuery]string name,
                     [FromQuery]string state,
                     [FromQuery]string zipcode,
                     [FromQuery]bool indeFlag,
                     [FromQuery]string email)
         {
             // Your code here
         }
    
    }
