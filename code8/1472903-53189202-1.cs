    // ASP.NET -> Models
    public class CurrentUserModel
    {
        public CurrentUserModel(...) 
        {
            // initialize properties
        }
        public bool IsAuthenticated { get; }
        public string Username { get; }
        // other properties go here
    }
    // ASP.NET -> Controllers
    public class UserController : ApiController 
    {
        // GET /user/current
        [HttpGet] 
        [AllowAnonymous]
        public async Task<CurrentUserModel> Current()
        {
            CurrentUserModel model = new CurrentUserModel(...);
            return Ok(model);            
        }
    }
    // Client-side
    <script>
        apiClient.user.current().then(u => {
            // work with user details here
        });
    </script>
