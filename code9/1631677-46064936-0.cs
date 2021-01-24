    .AddOAuth("LinkedIn", 
                c =>
                {
                    c.ClientId = Configuration["linkedin-app-id"];
                    c.ClientSecret = Configuration["linkedin-app-secret"];
                    c.Scope.Add("r_basicprofile");
                    c.Scope.Add("r_emailaddress");
                    c.CallbackPath = "/signin-linkedin";
                    c.AuthorizationEndpoint = "https://www.linkedin.com/oauth/v2/authorization";
                    c.TokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";
                    c.UserInformationEndpoint = "https://api.linkedin.com/v1/people/~:(id,formatted-name,email-address,picture-url)";
                    c.Events = new OAuthEvents
                    {
                        OnCreatingTicket = async context =>
                        {
                            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                            request.Headers.Add("x-li-format", "json");
    
                            var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
                            response.EnsureSuccessStatusCode();
                            var user = JObject.Parse(await response.Content.ReadAsStringAsync());
    
                            var userId = user.Value<string>("id");
                            if (!string.IsNullOrEmpty(userId))
                            {
                                context.Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                            }
    
                            var formattedName = user.Value<string>("formattedName");
                            if (!string.IsNullOrEmpty(formattedName))
                            {
                                context.Identity.AddClaim(new Claim(ClaimTypes.Name, formattedName, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                            }
    
                            var email = user.Value<string>("emailAddress");
                            if (!string.IsNullOrEmpty(email))
                            {
                                context.Identity.AddClaim(new Claim(ClaimTypes.Email, email, ClaimValueTypes.String,
                                    context.Options.ClaimsIssuer));
                            }
                            var pictureUrl = user.Value<string>("pictureUrl");
                            if (!string.IsNullOrEmpty(email))
                            {
                                context.Identity.AddClaim(new Claim("profile-picture", pictureUrl, ClaimValueTypes.String,
                                    context.Options.ClaimsIssuer));
                            }
                        }
                    };
    
                })
