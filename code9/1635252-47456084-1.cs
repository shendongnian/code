    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOAuth("Twitch", "Twitch", o =>
                  {
                      o.SignInScheme = IdentityConstants.ExternalScheme;
                      o.ClientId = "MY CLIENT ID";
                      o.ClientSecret = "MY CLIENT SECRET";
                      o.CallbackPath = "/signin-twitch";
                      o.ClaimsIssuer = "Twitch";
                      o.AuthorizationEndpoint = "https://api.twitch.tv/kraken/oauth2/authorize";
                      o.TokenEndpoint = "https://api.twitch.tv/api/oauth2/token";
                      o.UserInformationEndpoint = "https://api.twitch.tv/helix/users";
                      o.Scope.Add("openid");
                      o.Scope.Add("user:read:email");
                      o.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
                      {
                          OnCreatingTicket = async context =>
                          {
                              var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                              request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                              request.Headers.Add("x-li-format", "json");
                              var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
                              response.EnsureSuccessStatusCode();
                              var user = JObject.Parse(await response.Content.ReadAsStringAsync());
                              var data = user.SelectToken("data")[0];
                              var userId = (string)data["id"];
                              if (!string.IsNullOrEmpty(userId))
                              {
                                  context.Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                              }
                              var formattedName = (string)data["display_name"];
                              if (!string.IsNullOrEmpty(formattedName))
                              {
                                  context.Identity.AddClaim(new Claim(ClaimTypes.Name, formattedName, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                              }
                              var email = (string)data["email"];
                              if (!string.IsNullOrEmpty(email))
                              {
                                  context.Identity.AddClaim(new Claim(ClaimTypes.Email, email, ClaimValueTypes.String,
                                      context.Options.ClaimsIssuer));
                              }
                              var pictureUrl = (string)data["profile_image_url"];
                              if (!string.IsNullOrEmpty(pictureUrl))
                              {
                                  context.Identity.AddClaim(new Claim("profile-picture", pictureUrl, ClaimValueTypes.String,
                                      context.Options.ClaimsIssuer));
                              }
                          }
                      };
                  });
