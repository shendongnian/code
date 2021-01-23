    public override int SaveChanges()
    {
        foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == 
                                       System.Data.Entity.EntityState.Deleted).ToList())
        {
            var delPropName = "IsDeleted";
            if (entry.OriginalValues.PropertyNames.Contains(delPropName))
            {
                var delProp = entry.Property(delPropName);
                delProp.CurrentValue = true;
                entry.State = System.Data.Entity.EntityState.Modified;
            }
        }
        return base.SaveChanges();
    }
