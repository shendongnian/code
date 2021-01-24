     public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
        
                if (allowedOrigin == null)
                {
                    allowedOrigin = "*";
                }
        
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
        
                /* db based authenication*/
                var user = ValidateUser(context.UserName.Trim(), context.Password.Trim());
                if (user != null)
                {
                    /* db based authenication*/
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    identity.AddClaim(new Claim("sub", context.UserName));
        
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        { 
                            "Status", "Success"
                        },
                        { 
                            "StatusCode", "200"
                        },
                        { 
                            "data", context.UserName.Trim()
                        },
                        { 
                            "message", "User valid"
                        }
                    });
        
                    var ticket = new AuthenticationTicket(identity, props);
                    //add token to header
                    
                    context.Validated(ticket);
    // TRY THIS
                context.Request.Context.Authentication.SignIn(identity);
                }
                else
                {
                    context.Rejected();
                    //_reponse = _util.Create(0, HttpStatusCode.Forbidden, message: "User Invaid.", data: null);
        
                }
        
    //RETURN YOUR DTO
        Task.FromResult< ResponseTO >(new ResponseTO{ //your properties filled });
            }
