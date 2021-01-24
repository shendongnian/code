    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
         private readonly ApplicationDbContext _dataContext;
         private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(ApplicationDbContext dataContext, UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            // Inject the datacontext and userManager Dependencies
            _dataContext = dataContext;
            _userManager = userManager;
        }
        
        // HTTPGET Controller action to edit user
        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }
         // HTTPPOST Controller action to edit user
        [HttpPost]
        public async Task<IActionResult> EditUser(string Id,UserViewModel model)
        {
            //Get User by the Id passed in.
            var user = await _userManager.FindByIdAsync(Id);
            
            //edit user: replace values of UserViewModel properties 
            user.Summary = model.Summary;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.RoleType = model.RoleType;
            user.Address = model.Address;
            user.City = model.City;
             //add user to the datacontext (database) and save changes
            _dataContext.Update(user);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("ACTION_NAME", "CONTROLLER_NAME");
            //this could be
            //return RedirectToAction("Index", "Home");
        }
    }
    
