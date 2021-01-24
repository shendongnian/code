    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller {
        private readonly IUserContextServices _userContextServices;
        private readonly User loggedUser;
        public UserController(IUserContextServices userContextServices) {
            _userContextServices = userContextServices;
        }
        //...
    }
