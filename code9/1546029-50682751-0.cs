    public void Validate()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
            .Select(e => e.Entity)
            .ToList();
                       
        foreach (var entity in entities)
        {
            var validationContext = new ValidationContext(entity);
            Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
        }
    }
