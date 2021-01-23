    var userName = ((this.LoginView1.FindControl("username") as TextBox).Text;
    //...
    switch (result)
    {
        case SignInStatus.Success:
            var loggedInUser = manager.FindByName(userName);
            //Do your log with loggedInUser!
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            break;
        //...
    }
