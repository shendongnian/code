    public class MyController : BaseController
    {
        public async Task<IActionResult> DoSomething()
        {
    
          var account = await GetAccount(); 
    
          //do something and you can call both _context and _identityService directly in any method in MyController
    
          Return Ok();
        }
    }
