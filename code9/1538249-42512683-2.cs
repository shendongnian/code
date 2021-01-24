    public class udb:DbContext
    {
            public udb()
            {
              Database.SetInitializer<udb>(new CreateDatabaseIfNotExists<udb>());
            }
            public DbSet<klasa> Keuni { get; set; }
            public DbSet<student> Seuni { get; set; }
    }
