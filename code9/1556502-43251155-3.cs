    public class AdminController : Controller
    {
     //rest code
     private ApplicationUserManager _userManager;
     
     public AdminController()
     {
     }
     public AdminController(ApplicationUserManager userManager)
     {
        UserManager = userManager;
     }
     public ApplicationUserManager UserManager
     {
        get
         {
          return _userManager ?? 
          HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
          }
        private set
          {
           _userManager = value;
          }
      }
      //then rest code, what ever you have 
      //Add this bellow code inside the Method, where you want to fetch the 
      //roles by username
      var myRoles = UserManager.FindByName("nirav@gmail.com").Roles;
      //then rest code
