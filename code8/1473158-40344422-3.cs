	private static List<string> _authenticatedUsers = new List<string>();
	
	public static AuthenticateUser (MyApplicationUser user)
	{
		if(!_authenticatedUsers.ContainsKey(user.Username))
		{
			_authenticatedUsers.Add(user.Username);
		}
	}
	
	public static DeauthenticateUser (MyApplicationUser user)
	{
		if(_authenticatedUsers.ContainsKey(user.Username))
		{
			_authenticatedUsers.Remove(user.Username);
		}
	}
	
	public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
	{
	  if (FormsAuthentication.CookiesSupported)
	  {
		if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
		{
		  try
		  {
			FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(
			  Request.Cookies[FormsAuthentication.FormsCookieName].Value);
			
			MyApplicationUser user = JsonConvert.DeserializeObject(ticket.UserData);
			
			if(user == null || !_authenticatedUsers.Any(u => u == user.Username))
			{ 
                // this invalidates the user
				args.User = null;
                Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
                HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                DateTime now = DateTime.Now;
                myCookie.Value = "a";
                myCookie.Expires = now.AddHours(-1);
                Response.Cookies.Add(myCookie);
                Response.Redirect(FormsAuthentication.LoginUrl);
                Resonpse.End();
			}
		  }
		  catch (Exception e)
		  {
			// Decrypt method failed.
            // this invalidates the user
			args.User = null;
            Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
            HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            DateTime now = DateTime.Now;
            myCookie.Value = "a";
            myCookie.Expires = now.AddHours(-1);
            Response.Cookies.Add(myCookie);
            Response.Redirect(FormsAuthentication.LoginUrl);
            Resonpse.End();
		  }
		}
	  }
	  else
	  {
		throw new HttpException("Cookieless Forms Authentication is not " +
								"supported for this application.");
	  }
	}
	
	
