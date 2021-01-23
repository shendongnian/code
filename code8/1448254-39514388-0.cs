    public override int SaveChanges()
    {
        var allTrackedEntities = this.ChangeTracker.Entries().ToList();
        return base.SaveChanges();
    }
