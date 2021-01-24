    public class DataModelContext : DbContext
    {
            public DbSet<CommonEntity> CommonEntity { get; set; }
            public DbSet<Address> Addresses { get; set; }
    }
