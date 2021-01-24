    public class PeopleContext : DbContext {
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CustomerService>().HasBaseType<Person>();
            modelBuilder.Entity<Sales>().HasBaseType<Person>();
        }
    }
