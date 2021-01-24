    var result = await context.Request.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);//AuthenticationOptions.DefaultAuthenticateScheme)
                if (result.Succeeded)
                {
                    //context.User.AddIdentity(result.Principal);
                    context.User = result.Principal;
                }
