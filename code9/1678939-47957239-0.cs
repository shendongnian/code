    [Produces("application/json")]
    [Route("api/Members")]
    public class MembersController : Controller {
    
        //Matches POST api/members/authenticate
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthModel model) {
            String email = model.email;
            String password = model.password
            
            //fake async task
            await Task.Delay(1);
    
            return Ok();
        }
        
        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] int id) {
            ///the boiler plate method that gets called
            //fake async task
            await Task.Delay(1);
    
            return Ok();
        }
    
    }
