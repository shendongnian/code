    [HttpPost]
    		[AllowAnonymous]
    		[ValidateAntiForgeryToken]
    		public void ExternalLogin(string provider)
    		{
    			string redirectUri = Url.Action("ExternalLoginCallback");
    
    			var properties = new AuthenticationProperties() { RedirectUri = redirectUri };
    			HttpContext.GetOwinContext().Authentication.Challenge(properties, provider);
    
    			// Stop execution of the current page/method - the 401 forces OWIN to kick-in and do its thing
    
    			Response.StatusCode = 401;
    			Response.End();
    		}
