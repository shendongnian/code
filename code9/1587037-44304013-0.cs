    app.UseIdentity();
    
                app.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                    Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = (context) =>
                        {
                            var cul = context.HttpContext.Features.Get<IRequestCultureFeature>();
                            var lang = cul.RequestCulture.Culture.TwoLetterISOLanguageName;
    
    
                            context.Response.Redirect($"/{lang}/Account/Login?{context.Options.ReturnUrlParameter}" +
                                 $"={System.Net.WebUtility.UrlEncode(context.Request.Path + context.Request.QueryString)}");
                            return Task.FromResult(0);
                        },
    
                    }
                });
