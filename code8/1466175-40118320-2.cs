    public class Person
    {
        public Person()
        {
            Managers = new HashSet<Manager>();
        }
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
    public class Manager
    {
        public Manager()
        {
            Persons = new HashSet<Person>();
        }
        [Key]
        public int ManagerId { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
    public class CompanyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Manager> Managers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
               .HasMany(p => p.Managers).WithMany(m => m.Persons)
               .Map(t => t.MapLeftKey("PersonID")
                   .MapRightKey("ManagerID")
                   .ToTable("PersonToManager"));
        }
    }
