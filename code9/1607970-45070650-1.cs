    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        //...
        return base.SaveChanges();
    }
