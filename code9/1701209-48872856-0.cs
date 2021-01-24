     public class BaseLogContext : DbContext
    {
        public DbSet<AccessLog> AccessLogs { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<ExceptionLog> ExeptionLogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLog>()
                .HasRequired(x => x.AccessLog)
                .WithOptional(x => x.ErrorLog);
                
            modelBuilder.Entity<ExceptionLog>()
                .HasRequired(x => x.AccessLog)
                .WithOptional(x => x.ExceptionLog);
            modelBuilder.Entity<ErrorLog>()
                .HasKey(x => x.AccessLogID);
            modelBuilder.Entity<ExceptionLog>()
               .HasKey(x => x.AccessLogID);
            base.OnModelCreating(modelBuilder);
        }
    }
    public abstract class BaseLogObject
    {
        public BaseLogObject()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
    }
    public class AccessLog : BaseLogObject
    {
        [Display(Name = "Ip Address")]
        public string IpAddress { get; set; }
        public virtual ErrorLog ErrorLog { get; set; }
        public virtual ExceptionLog ExceptionLog { get; set; }
    }
    public class ErrorLog 
    {
        public string Error { get; set; }
        [Display(Name = "Access Log")]
        public Guid AccessLogID { get; set; }
        public virtual AccessLog AccessLog { get; set; }
    }
    public class ExceptionLog 
    {
        public string Exception { get; set; }
        [Display(Name = "Access Log")]
        public Guid AccessLogID { get; set; }
        public virtual AccessLog AccessLog { get; set; }
    }
