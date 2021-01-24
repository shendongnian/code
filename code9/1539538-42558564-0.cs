    public class EFDataContext : DbContext
    {       
        public IDbSet<Person> People { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id)
                .ToTable(Settings.Default.PeopleTable);
        }
    }
