    public class SalesERPDAL: DbContext
    {
       public SalesERPDAL() : base("connectionStringName") { }
      public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
    }
