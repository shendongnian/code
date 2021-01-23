    protected void RedirectToLogin_Click(object sender, EventArgs e)
    {
      // gets a provider name from the data-provider
      string provider = ((LinkButton)sender).Attributes["data-provider"];
      // build the return address
      string returnUrl = new Uri(Request.Url, "ExternalLoginResult.aspx").AbsoluteUri;
      // redirect user into external site for authorization
      OAuthWeb.RedirectToAuthorization(provider, returnUrl);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       var result = OAuthWeb.VerifyAuthorization();
          
       Response.Write(String.Format("Provider: {0}<br />", result.ProviderName));
          
       if (result.IsSuccessfully)
       {
          // successfully
          var user = result.UserInfo;
          Response.Write(String.Format("User ID:  {0}<br />", user.UserId));
          Response.Write(String.Format("Name:     {0}<br />", user.DisplayName));
          Response.Write(String.Format("Email:    {0}", user.Email));
        }
        else
        {
          // error
          Response.Write(result.ErrorInfo.Message);
        }
     }
