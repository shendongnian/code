    public class AccountController : Controller
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AccountController"/> class.
            /// </summary>
            public AccountController()
                : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            {
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="AccountController"/> class.
            /// </summary>
            /// <param name="userManager">The user manager.</param>
            public AccountController(UserManager<ApplicationUser> userManager)
            {
                UserManager = userManager;
            }
    
            /// <summary>
            /// Gets the user manager.
            /// </summary>
            /// <value>
            /// The user manager.
            /// </value>
            public UserManager<ApplicationUser> UserManager { get; private set; }
    
            //
            // GET: /Account/Login
            /// <summary>
            /// Logins the specified return URL.
            /// </summary>
            /// <param name="returnUrl">The return URL.</param>
            /// <returns></returns>
            [AllowAnonymous]
            public ActionResult Login(string returnUrl)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
    
            //
            // POST: /Account/Login
            /// <summary>
            /// Logins the specified model.
            /// </summary>
            /// <param name="model">The model.</param>
            /// <param name="returnUrl">The return URL.</param>
            /// <returns></returns>
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindAsync(model.UserName, model.Password);
                    if (user != null)
                    {
                        await SignInAsync(user, model.RememberMe);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
    private async Task SignInAsync(ApplicationUser user, bool isPersistent)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
            }
