    public class DivorceCases
    {
        public string case_id { get; set; }
        public virtual Transactions t { get; set; }
    }
    
    public class CorporationCases
    {
        public string case_id { get; set; }
        public virtual Transactions t { get; set; }
    }
    
    public class YourCasesContext : DbContext
    {
        public YourCasesContext () : base("mssqlDB") { }
    
        public DbSet<DivorceCases> DivorceCase { get; set; }
        public DbSet<CorporationCases> CorporationCase { get; set; }
    }
