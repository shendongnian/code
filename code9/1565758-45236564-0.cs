       `[HttpPost]
        public string FacebookLogin()
        {
            try
            {
                // Instantiate the Facebook client
                var oauth = new FacebookClient();                
                var fbLoginUrl = oauth.GetLoginUrl(new
                {
                    client_id = "Enter ApplicationID",
                    client_secret = "Enter ApplicationSecret",
                    redirect_uri = "Enter RedirectUri",
                    response_type = "code",
                    scope = "manage_pages,email" // Add other permissions as needed
                });
                var fbloginUri = fbLoginUrl.AbsoluteUri;
				Session["ClientId"] = "Enter ApplicationID",                
                return fbloginUri;
            }
            catch (Exception)
            {
                return null;
            }            
        }` 
