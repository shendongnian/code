    public class MyContext : IdentityDbContext<IdentityUser>
    {
            public MyContext() : base("MyContext")
            {
            }
    
    
            internal void CreateDefaultUsers()
            {
                if (!Roles.Any(r => r.Name == "admin"))
                {
                    var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                    RoleManager.Create(new IdentityRole("admin"));
                }
    
    
                if (!Users.Any(u => u.UserName == "myadmin"))
                {
                    var store = new UserStore<IdentityUser>(this);
                    var manager = new UserManager<IdentityUser>(store);
    
                    var user = new IdentityUser { UserName = "myadmin" };
    
                    manager.Create(user, "mysupersafepwlulz");
                    manager.AddToRole(user.Id, "admin");
                }
            }
         //More stuff not relevang for the question...
    
    }
