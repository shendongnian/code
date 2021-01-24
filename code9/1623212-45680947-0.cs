    [Produces("application/json")]
    [RoutePrefix("Users")] // different attribute here and not starting /slash
    public class UserController 
    {
        // Gets a specific user
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            // do what needs to be done
        }
        // Gets all visits from a specific user
        [HttpGet]
        [Route("{id}/visits")]
        public async Task<IActionResult> GetUserVisits([FromRoute] long id) // method name different
        {
            // do what needs to be done
        }
    }
