    private void GenerateIds()
    {
        // fetch all added entries that have IGuid
        IEnumerable<IGuid> addedIGuidEntries = this.ChangeTracker.Entries()
            .Where(entry => entry.State == EntityState.Added)
            .OfType<IGuid>()
        // if IGuid.Id is default: generate a new Id, otherwise leave it
        foreach (IGuid entry in addedIGuidEntries)
        {
            if (entry.Id == default(Guid)
                // no value provided yet: provide it now
                entry.Id = GenerateGuidId() // TODO: implement function
            // else: Id already provided; use this Id.
        }
    }
