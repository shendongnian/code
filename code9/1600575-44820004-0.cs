    public override int SaveChanges()
    {
        var detectChanges = this.Configuration.AutoDetectChangesEnabled;
        try
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            return base.SaveChanges();
        }
        finally
        {
            this.Configuration.AutoDetectChangesEnabled = detectChanges;
        }
    }
