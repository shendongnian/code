     public class PortalEntities : DbContext
        {
            public DbSet<Delegate> Delegates { get; set; }
            public DbSet<Status> Statuses { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                Database.SetInitializer<PortalEntities>(null);
                base.OnModelCreating(modelBuilder);
            }
        }
    
    <connectionStrings>
    
        <add name="PortalEntities" connectionString="Data Source=serverName;Integrated Security=true;Initial Catalog=dbName;" providerName="System.Data.SqlClient"/>
        
    </connectionStrings>
