    public ActionResult Login(LoginModel model,string returnUrl)
            {
                var getTokenUrl = string.Format(ApiEndPoints.AuthorisationTokenEndpoint.Post.Token, ConfigurationManager.AppSettings["ApiBaseUri"]);
    
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpContent content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"), 
                        new KeyValuePair<string, string>("username", model.EmailAddress), 
                        new KeyValuePair<string, string>("password", model.Password)
                    });
    
                    HttpResponseMessage result = httpClient.PostAsync(getTokenUrl, content).Result;
    
                    string resultContent = result.Content.ReadAsStringAsync().Result;
    
                    var token = JsonConvert.DeserializeObject<Token>(resultContent);
    
                    AuthenticationProperties options = new AuthenticationProperties();
    
                    options.AllowRefresh = true;
                    options.IsPersistent = true;
                    options.ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(token.expires_in));
    
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, model.EmailAddress),
                        new Claim("AcessToken", string.Format("Bearer {0}", token.access_token)),
                    };
    
                    var identity = new ClaimsIdentity(claims, "ApplicationCookie");
    
                    Request.GetOwinContext().Authentication.SignIn(options, identity);
    
                }
    
                return RedirectToAction("Index", "Home");
            }
  
