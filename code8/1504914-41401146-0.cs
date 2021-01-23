     Provider = new CookieAuthenticationProvider()
                {
                    OnApplyRedirect = context =>
                    {
                        if (!context.Request.Path.StartsWithSegments(new PathString("/api")))
                            context.Response.Redirect(context.RedirectUri);
                    },
                    OnValidateIdentity = async context =>
                    {
                        var uow = DependencyResolver.Current.GetService<IUnitOfWork>();
                        var user = await uow.UsersRepository.FindUserByIdAsync(context.Identity.GetUserId());
                        uow.Reload(user);
                        var oldSecurityStamp = (context.Identity as ClaimsIdentity)
               .Claims.Where(x => x.Type.Equals(ClaimTypes.Expiration))
               .FirstOrDefault().Value;
                        if (!user.SecurityStamp.Equals(oldSecurityStamp))
                        {
                            context.RejectIdentity();
                            context.OwinContext.Authentication.SignOut(context.Options.AuthenticationType);
                        }
                    }
                    /*SecurityStampValidator.OnValidateIdentity<UserManager<User>, User, string>(
                        validateInterval: TimeSpan.FromSeconds(15),
                        regenerateIdentityCallback: (mngr, usr) =>
                        {
                            Debug.WriteLine("Regenerate identity");
                            var rolesStr = (mngr.GetRoles(usr.Id)).ToArray();
                            return AccountController.CreateClaims(usr, rolesStr);
                        },
                        getUserIdCallback: ci =>
                        {
                            return ci.GetUserId();
                        }).Invoke(context)*/
                },
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/"),
                CookieName = "Alisary",
                ExpireTimeSpan = TimeSpan.FromMinutes(20),
                SlidingExpiration = true,
            });
