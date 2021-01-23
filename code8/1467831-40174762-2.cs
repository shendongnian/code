    public override int SaveChanges(SaveOptions options)
    {
        foreach (ObjectStateEntry entry in
            ObjectStateManager.GetObjectStateEntries(
            EntityState.Added | EntityState.Modified))
        {
            // Validate the objects in the Added and Modified state
            // if the validation fails, e.g. throw an exeption.
        }
        return base.SaveChanges(options);
    }
