      app.Use(async (context, next) =>
            {
                var id = context.User.Claims.First(x => x.Type == "sub").Value;
                using(var db = context.RequestServices.GetService<MyDbContext>())
                {
                   
                   var user = db.AspNetUsers.Find(id);
                   user.LastAccessed = DateTime.Now;
                   await db.SaveChangesAsync();
                }
                await next();
            });
