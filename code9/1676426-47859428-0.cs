    public class SomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> SomeAction()
        {
            var myNewBalance = new Balance();
            myNewBalance.User = await _userManager.GetUserAsync(User);
            return View(); // etc, etc.
        }
    }
