    public class CompanyController : Controller 
    {
        private readonly Lazy<ApplicationUser> user;
    
        private readonly Lazy<bool> userIsSysAdmin;
    
        public CompanyController()
        {
        }
    
        public CompanyController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            this.user = new Lazy<ApplicationUser>(() => UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()));
            this.userIsSysAdmin = new Lazy<bool>(() => UserManager.GetRoles(User.Id).Any(u => u == "Sys Admin"));
        }
    
        public ApplicationUser User
        {
            get { return this.user.Value; }
        }
    
        public bool UserIsSysAdmin
        {
            get { return this.userIsSysAdmin.Value; }
        }
    
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
