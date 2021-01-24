    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        var member = Membership.GetUser(txtEmail.Text);
        if (member != null)
        {
            if (member.IsLockedOut)
            {
                if (DateTime.Now.Subtract(member.LastLockoutDate).TotalMinutes > 10)
                {
                    member.UnlockUser();
                }
                else
                {
                    (Page as BasePage).Alert("Your account due to entering the wrong credentials more than 5 times, has been blocked, please right after 10 minutes to re-enter your user information.");
                    return;
                }
            }
        }
    
        if (Membership.ValidateUser(txtEmail.Text, txtPassword.Text))
        {
            if (Request.QueryString["ReturnUrl"] != null)
            {
                FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, false);
            }
            else
            {
                if (Roles.IsUserInRole(txtEmail.Text, SiteUtility.SiteRoles.admin.ToString()) || Roles.IsUserInRole(txtEmail.Text, SiteUtility.SiteRoles.adminl2.ToString()))
                {
                    FormsAuthentication.SetAuthCookie(txtEmail.Text, false);
                    Response.Redirect("/admin/");
                }
            }
        }
        else
        {
            if (Page is BasePage)
            {
                (Page as BasePage).Alert("Username or password is incorrect.");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "alterror", "alert('Username or password is incorrect.');", true);
            }
        }
    }
