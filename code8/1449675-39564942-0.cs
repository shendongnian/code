    private class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {
            Database.SetInitializer<UsersContext>(null);
	        try
	        {
     		    using (var context = new UsersContext())
     		    {
           	        if (!context.Database.Exists())
           	        {
                	    // Create the SimpleMembership database without Entity Framework migration schema
                	    ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
           	        }
     		    }
     
     		    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
    // also set your DB connection string on current DB context
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
