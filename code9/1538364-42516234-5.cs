    [RoutePrefix("api/users/{userId:guid}/locations")]
    public partial class UsersController : MyCustomApiController { 
        [HttpPost]
        [Route("{locationId:guid}/list")]
        public async Task<IHttpActionResult> GetUsers(Guid userId, Guid locationId, [FromBody] Contracts.UserRequest request) { ... }
    }
