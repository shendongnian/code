    public class LoginViewModel
    {
       [Display(Name = "Username")]
       [Required(ErrorMessage = "Please enter your username.")]
       public string UserName { get; set; }
    }
    public async Task<ActionResult> Login(LoginModel model, string returnUrl)
    {
       if (ModelState.IsValid)
       {
          ...
          ModelState.AddModelError("", "User is not authorized!");
       }
       ...
    }
