    [Route("[controller]")]
    public class UserController : Controller
    {
    
         [Route("add")] 
         [HttpPost]    
         public async Task<IActionResult> Create(
                     [FromForm]string name,
                     [FromForm]string state,
                     [FromForm]string zipcode,
                     [FromForm]Boolean indeFlag,
                     [FromForm]string email)
         {
             // Your code here
         }
    
    }
