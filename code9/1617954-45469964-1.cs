          protected void Application_AuthenticateRequest(object sender, EventArgs e)
            {
               //Check the request for a cookie
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
    
                if (authCookie != null)
                {
                    //Decrypt the Auth Cookie vale
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    
                    //Instantiate Auth Service
                    var _authService = new AuthenticationService();
                    
                    //Get user by encrypted name stored in ticket
                    var user = _authService.GetUserByUserName(ticket.Name);
                    if (user != null)
                    {
                        // Create a ClaimsIdentity with all the claims for this user.
    
                        Claim emailClaim = new Claim("Email", (!string.IsNullOrWhiteSpace(user.Email)) ? user.Email: "");
                        Claim AddressClaim = new Claim("Address", (!string.IsNullOrWhiteSpace(user.Address)) ? user.Address: "");
                        Claim userNameClaim = new Claim(ClaimTypes.Name, (!string.IsNullOrWhiteSpace(user.Username)) ? user.Username : "");
    
                       //Add claims to a collection of claims
                        List<Claim> claims = new List<Claim>
                        {
                            emailClaim ,
                            AddressClaim ,
                            userNameClaim 
                        };
    
                       //Create forms Identity
                        FormsIdentity formsIdentity = new FormsIdentity(ticket);
    
                       //Create Claims Identity
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(formsIdentity);
    
                       //Add Claims
                        claimsIdentity.AddClaims(claims);
    
                       //Create Claims Principal
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    
                        //Assign principal to current user
                        HttpContext.Current.User = claimsPrincipal;
                    }
                }
            }
