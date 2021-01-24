    private void GenerateIds()
    {
        // fetch all added entries that implement ISelfGeneratedId
        var addedIdEntries = this.ChangeTracker.Entries()
            .Where(entry => entry.State == EntityState.Added)
            .OfType<ISelfGeneratedId>()
        foreach (ISelfGeneratedId entry in addedIdEntries)
        {
            entry.Id = this.GenerateId() ;// TODO: implement function
            // now you see why I need the interface:
            // I need to know the primary key
        }
    }
