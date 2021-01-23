    [Route("[controller]")]
    public class UserController : Controller
    {
    
         [Route("add")] 
         [HttpPost]    
         public async Task<IActionResult> Create(
                     AddViewModel model)
         {
             if (ModelState.IsValid)
             {
                  // Put your code to create user here
             }
             else
             {
                  // Put your code for error here
             }
         }
    
    }
