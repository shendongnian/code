    public class User : IUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UserContext : BaseContext<UserContext>
    {
        public DbSet<User> Users { get; set; }
    }
