    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class Context : DbContext
    {
        public DbSet<User> Users {get; set;}
        
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Properties().Where(p => p.Name == "Country").Configure(x => x.ClrPropertyInfo.SetValue(currentInstanceOfUser, "USA"));
        }
    }
