    public class ItemRental
    {
        [Column("ItemRentalId")] //new
        public Int32 Id { get; set; } //new
        public Int32? OriginatingSalesOrderId { get; set; }
        [ForeignKey("OriginatingSalesOrderId")]
        public SalesOrder OriginatingSalesOrder { get; set; }
        public Int32? DepositCreditedOnSalesOrderId { get; set; }
        [ForeignKey("DepositCreditedOnSalesOrderId")]
        public SalesOrder DepositCreditedOnSalesOrder { get; set; }
    }
    public class SalesOrder
    {
        [Column("SalesOrderId")] //new
        public Int32 Id { get; set; } //new
        [InverseProperty("OriginatingSalesOrder")]
        public ICollection<ItemRental> Rentals { get; set; }
        [InverseProperty("DepositCreditedOnSalesOrder")]
        public ICollection<ItemRental> Refunds { get; set; }
    }
    public class MyAppDatabase : DbContext
    {
        public MyAppDatabase(DbContextOptions<MyAppDatabase> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ItemRental> ItemRentals { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        }
