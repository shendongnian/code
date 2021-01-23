        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<InvoiceDayRelationship>()
                .HasKey(id => new { id.DayId, id.InvoiceId });
            builder.Entity<InvoiceJobRelationship>()
                .HasKey(ij => new { ij.JobId, ij.InvoiceId });
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<InvoiceDayRelationship> InvoiceDays { get; set; }
        public DbSet<InvoiceJobRelationship> InvoiceJobs { get; set; }
