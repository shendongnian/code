    public class DatabaseContext : DbContext    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            this.MinimallySeedDatabase();
        }
        public void MinimallySeedDatabase()
        {
            State NY = this.States.Where(s => s.Abbr.Equals("NY")).FirstOrDefault();
            if (null == NY)
            {
                NY = new State {
                    Name = "New York",
                    Abbr = "NY"
                };
                this.States.Add(NY);
                this.SaveChanges();
            }
            
            // etc etc etc...
        }
        
        public DbSet<Contact> Contacts {get; set;}
        public DbSet<Address> Addresses {get; set;}
        public DbSet<AddyType> AddyTypes {get; set;}
        public DbSet<State> States {get; set;}
    }
            
