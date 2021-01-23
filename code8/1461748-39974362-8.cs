    public new void SaveChanges()
    {
        foreach (var entry in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Modified))
        {
            entry.ModifyTypes<DateTimeOffset>(ConvertToUtc);
            entry.ModifyTypes<DateTimeOffset?>(ConvertToUtc);
        }
        base.SaveChanges();
    }
