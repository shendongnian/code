    public class LoginViewModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
    // ...
    [HttpPost]
    [AllowAnonymous]
    public ActionResult Index(LoginViewModel model)
    {
        if(CheckUserCredentialsAgainstDB(model.UserId, model.Password))
        {
            // ...
        }
        // ...
     }
