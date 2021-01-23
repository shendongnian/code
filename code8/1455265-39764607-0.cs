    namespace MyNamespace
    {
        public class MyContext: IdentityDbContext<IdentityUser>
            {
        
                public MyContext() : base("DefaultConnection")
                {
                    if (!Roles.Any(r => r.Name == "admin"))
                    {
                        var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                        RoleManager.Create(new IdentityRole("admin"));
                    }                
                    
        
                    if (!Users.Any(u => u.UserName == "mydefaultuser"))
                    {
                        var store = new UserStore<IdentityUser>(this);
                        var manager = new UserManager<IdentityUser>(store);
                    
                        var user = new IdentityUser { UserName = "mydefaultuser" };
        
                        manager.Create(user, "password");
                        manager.AddToRole(user.Id, "admin");
                    }
                }
        
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);
                    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                }
        
                public DbSet<MyItem1> myStuff1 { get; set; }
                public DbSet<MyItem2> myStuff2 { get; set; }
                public DbSet<MyItem3> myStuff3 { get; set; }
                public DbSet<MyItem4> myStuff4 { get; set; }
                public DbSet<MyItem5> myStuff5 { get; set; }
            }
    }
