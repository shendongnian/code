    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [ForeignKey("EmpId")]
        public virtual EmployeeOption EmployeeOption { get; set; }
    }
    public class EmployeeOption
    {
        [Key]
        public int EmpId { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
    }
    public class ExampleContext : DbContext
    {
        public ExampleContext() : base("DefaultConnection") { this.Configuration.ProxyCreationEnabled = false; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOptional(o => o.EmployeeOption)
                .WithOptionalPrincipal(e => e.Employee);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeOption> EmployeeOptions { get; set; }
    }
