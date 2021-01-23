    private class PartyContext : DbContext
    {
        public PartyContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>().HasMany(typeof(Commission), "Commissions").WithOne();
        }
    }
    private class Party
    {
        public int PartyId { get; set; }
        protected ICollection<Commission> Commissions { get; set; }
    }
    private class Agency : Party
    {
        public new ICollection<Commission> Commissions
        {
            get { return base.Commissions; }
            set { base.Commissions = value; }
        }
    }
    private class Carrier : Party
    {
        public new ICollection<Commission> Commissions
        {
            get { return base.Commissions; }
            set { base.Commissions = value; }
        }
    }
    private class Commission
    {
        public int Id { get; set; }
    }
