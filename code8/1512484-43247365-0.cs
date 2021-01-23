    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
    var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
    var user = manager.FindByName(Email.Text);
    //check for credentials before sign in ..    
    var validCredentials = signinManager.UserManager.CheckPassword(user, Password.Text);
    if (validCredentials)
    {
        //sample code to run if user's credentials is valid and before login
        if(!manager.IsInRole(user.Id, "Administrators"))
        {
           FailureText.Text = "you need a higher permission level in order to login";
           return;
        }
    }
    //then sign in
    var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);
