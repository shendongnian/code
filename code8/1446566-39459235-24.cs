    public class User : IUser
    {
        [Key]
        public Guid Id { get; set; }
    }
    public class Building
    {
        [Key]
        public Guid Id { get; set; }
        public string Location { get; set; }
        public virtual User User { get; set; }
    }
    public class BuildingContext : BaseContext<BuildingContext>
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<User> Users { get; set; }
    }
