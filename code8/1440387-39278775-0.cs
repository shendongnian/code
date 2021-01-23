    public class EmployeeContext : DbContext
    {
        public DbSet<EmployeeBank> EmployeeBanks { get; set; }
        public DbSet<EmployeePaymentMethod> EmployeePaymentMethods { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeBank>()
                .HasMany(e => e.DoNotUseMeSir)
                .WithMany(b => b.DoNotUseMeSir)
                .Map(mc => mc.ToTable("BankToPaymentMethods")
                .MapLeftKey("EmployeeBankId")
                .MapRightKey("EmployeePaymentMethodId"));
        }
    }
    
    public class EmployeeBank
    {
        public EmployeeBank()
        {
            DoNotUseMeSir = new List<EmployeePaymentMethod>();
        }
    
        public int EmployeeBankId { get; set; }
        public string Name {get;set;}
    
        [NotMapped]
        public EmployeePaymentMethod EmployeePaymentMethod
        {
            get { return DoNotUseMeSir.FirstOrDefault(); }
            set
            {
                DoNotUseMeSir.Clear();
                DoNotUseMeSir.Add(value);
            }
        }
    
        public virtual ICollection<EmployeePaymentMethod> DoNotUseMeSir { get; set; }
    }
    
    public class EmployeePaymentMethod
    {
        public EmployeePaymentMethod()
        {
            DoNotUseMeSir = new List<EmployeeBank>();
        }
    
        public int EmployeePaymentMethodId { get; set; }
    
        [NotMapped]
        public EmployeeBank EmployeeBank
        {
            get { return DoNotUseMeSir.FirstOrDefault(); }
            set
            {
                DoNotUseMeSir.Clear();
                DoNotUseMeSir.Add(value);
            }
        }
    
        public virtual ICollection<EmployeeBank> DoNotUseMeSir { get; set; }
    }
    
    public class EmployeeDatabaseInitialiser : CreateDatabaseIfNotExists<EmployeeContext>
    {
        protected override void Seed(EmployeeContext context)
        {
            base.Seed(context);
    
            var employeeBankIdUc =
                "ALTER TABLE dbo.BankToPaymentMethods ADD CONSTRAINT uq_BankToPaymentMethods_EmployeeBankId UNIQUE(EmployeeBankId)";
            context.Database.ExecuteSqlCommand(employeeBankIdUc);
    
            var employeePaymentMethodIdUc =
                "ALTER TABLE dbo.BankToPaymentMethods ADD CONSTRAINT uq_BankToPaymentMethods_EmployeePaymentMethodId UNIQUE(EmployeePaymentMethodId)";
            context.Database.ExecuteSqlCommand(employeePaymentMethodIdUc);
        }
    }
