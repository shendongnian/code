    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
       [ImportingConstructor]
       public OrderConfiguration(IDbTenant tenant)
          : base()
       {
           ToTable("Orders", tenant.SchemaName);
           // HasKey(...);
           // HasMany(...);
           // etc. etc. etc.
       }
    }
