    public override int SaveChanges()
    {
        var distinctTenantIdsCount = this.ChangeTracker.Entries<IHasTenantId>()
                                         .Select(e => e.Entity.TenantId)
                                         .Distinct().Count();
        if(distinctTenantIdsCount > 1)
        {
            // Throw an exception and handle it.
        }
        return base.SaveChanges();
    }
