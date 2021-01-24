    public class AccountMobileController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly string _externalCookieScheme;
       
        // POST api/mobilelogin
        [AllowAnonymous]
        [HttpPost("/api/mobilelogin")]
        public async Task<IActionResult> Login([FromBody]LoginMobileResource model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = context.Users.SingleOrDefault(c => c.Email == model.Email);
                    /* _logger.LogInformation(1, "User logged in.");
                     return RedirectToLocal(returnUrl);*/
                    var modeltoreturn = new LoginMobileResource
                    {
                        Status = "Ok",
                        Email = user.Email,
                        Password= "",
                        RememberMe = model.RememberMe,
                        UserId = user.Id
                    };
                    return Ok(modeltoreturn);
                }
                else
                {
                    var modeltoreturn = new LoginMobileResource
                    {
                        Status = "Wrong password",
                        Email = model.Email,
                        Password = "",
                        UserId = ""
                    };
                    return Ok(modeltoreturn);
                }
            }
            // If we got this far, something failed, redisplay form
            model.Status = "Non-existent account";
            return Ok(model);
        }
     }
