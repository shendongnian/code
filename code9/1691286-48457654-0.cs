    List<DbEntityEntry> modifiedChanges = ChangeTracker.Entries().Where(x =>
                        x.State == EntityState.Added || x.State == EntityState.Modified)
                        .ToList();
    
    foreach (var change in modifiedChanges)
    {
        if (change.CurrentValues.PropertyNames.Contains("UserID"))
        {
            if (change.Entity.GetType().GetProperty("UserID").PropertyType == typeof(string))
            {
               change.Property("UserID").CurrentValue = userID;
            }
        }
    }
