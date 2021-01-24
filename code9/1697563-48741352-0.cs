            app.Use(async (context, next) => {
                await next.Invoke();
                //handle response
                //you may also need to check the request path to check whether it requests image
                if (context.User.Identity.IsAuthenticated)
                {
                    var userName = context.User.Identity.Name;
                    //retrieve uer by userName
                    using (var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>())
                    {
                        var user = dbContext.ApplicationUser.Where(u => u.UserName == userName).FirstOrDefault();
                        user.LastAccessed = DateTime.Now;
                        dbContext.Update(user);
                        dbContext.SaveChanges();
                    }
                }
            });
            app.UseAuthentication();
