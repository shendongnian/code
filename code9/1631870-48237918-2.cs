     public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
         
            if (user == null)
            {
                // برای کاربرانی که قبلا اکانت داشته اند که پسوردشان متفاوت با پسورد پیش فرض برای 
                //external logins
                //است
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["IsSSO"]))
                {
                    var authCode = HttpContext.Current.Request["AuthCode"];
                    if (!string.IsNullOrEmpty(authCode))
                    {
                        var emailInCache = ECS.Cache.CacheFacade.Get<string>(authCode);
                        if (!string.IsNullOrEmpty(emailInCache))
                        {
                            user = await userManager.FindByEmailAsync(emailInCache);
                            Cache.CacheFacade.Remove(authCode);
                        }
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "ایمیل/موبایل یا رمز عبور نا معتبر است");
                    return;
                }
            }
            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);
            AuthenticationProperties properties = CreateProperties(user.UserName);
            properties.Dictionary.Add(new KeyValuePair<string, string>("UserRegisterationType",((byte)user.RegistrationType).ToString()));
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            
        }
