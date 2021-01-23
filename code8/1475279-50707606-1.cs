    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    public class MyContext: DbContext
    {
        public DbSet<User> Users{ get; set; }
    
        public MyContext(DbContextOptions<MyContext> options)
            : base(options) { }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    
            builder.Entity<User>(table =>
            {
                // Similar to the table variable above, this allows us to get
                // an address variable that we can use to map the complex
                // type's properties
                table.OwnsOne(
                    x => x.Address,
                    address =>
                    {
                        address.Property(x => x.City).HasColumnName("City");
                        address.Property(x => x.State).HasColumnName("State");
                        address.Property(x => x.StreetAddress).HasColumnName("Address");
                        address.Property(x => x.SuiteNumber).HasColumnName("SuiteNumber");
                        address.Property(x => x.ZipCode).HasColumnName("Zip");
                    });
            });
        }
    }
