    protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<ClientDriverLoad>().HasMany(m => m.DriverLoads).WithRequired(m => m.ClientDriverLoad);
            mb.Entity<ClientDriverPayment>().HasRequired(m => m.Client).WithMany(m => m.ClientPayments);
    }
