    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    
    public AccountController (...){
    
        ....
       [HttpPost, ActionName("Register")]
       public IHttpActionResult SaveCustomer([FromBody] UserInfo user ){}
    }
