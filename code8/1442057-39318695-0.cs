    [Authorize]
    public class BaseController : Controller {
        protected ApplicationSignInManager _signInManager;
        protected ApplicationUserManager _userManager;
        protected IUnitOfWork UnitOfWork { get; set; }
        protected ApplicationUser _CurrentUser;
        public BaseController(IApplicationManager appManager) {
            UserManager = appManager.UserManager;
            SignInManager = appManager.SignInManager;
        }
        public ApplicationSignInManager SignInManager {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }
        protected IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
