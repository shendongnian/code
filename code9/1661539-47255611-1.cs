    public void LogIN()
    {
      string password = Page.Request.Form["TxtPassword"].ToString();
      string userName = Page.Request.Form["TxtUsername"].ToString();
      LoginResult result = ValidateLogin(userName, password); //I renamed IsValidLogin which implies a Boolean result.
    
      if (!result.IsValid)
      {
        ScriptManager.RegisterStartupScript(this, GetType(), "script", "DoValidate();", true);
        ShowMessage("Invalid username and password combination.", MessageType.Error);
        return;
      }
    
      switch(result.Role)
      {
        case UserRoles.User:
           Response.Redirect("Home_Page.aspx");
           break;
        case UserRoles.Admin:
           Response.Redirect("StaffHomepage_Page.aspx");
           break;
        default:
           // Handle something unexpected?
      }
    }
