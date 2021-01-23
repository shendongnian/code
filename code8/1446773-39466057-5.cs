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
    
    }
