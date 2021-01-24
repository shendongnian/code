    [Route("api/[controller]")]
    public class PermissionController : Controller {
    
        //Matches GET api/permission/1234/98766
        [HttpGet("{idUser}/{idPermission}", Name = "GetUserPermissionByID")]
        public async Task<IActionResult> GetUserPermissionByID(int idUser, int idPermission) {
            //...code removed for brevity
        }
    
    }
