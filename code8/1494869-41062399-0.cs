    public class UdstillingsmodelDBContext : DbContext
    {
        public UdstillingsmodelDBContext() : base("UdstillingsmodelDBContext") {}
        public DbSet<Udstillingsmodel> Udstillingsmodels { get; set; }
    }
