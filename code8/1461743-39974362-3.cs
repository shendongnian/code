    public new void SaveChanges()
    {
        foreach (var entry in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Modified))
            {
            foreach (var propertyInfo in entry.Entity.GetType().GetTypeProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)))
            {
                propertyInfo.SetValue(entry.Entity, entry.CurrentValues.GetValue<DateTimeOffset>(propertyInfo.Name).ToUniversalTime());
            }
            foreach (var propertyInfo in entry.Entity.GetType().GetTypeProperties().Where(p => p.PropertyType == typeof(DateTimeOffset?)))
            {
                var dateTimeOffset = entry.CurrentValues.GetValue<DateTimeOffset?>(propertyInfo.Name);
                if (dateTimeOffset != null) propertyInfo.SetValue(entry.Entity, dateTimeOffset.Value.ToUniversalTime());
            }
        }
         base.SaveChanges();
    }
