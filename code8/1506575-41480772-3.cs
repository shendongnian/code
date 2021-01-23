    _context.ChangeTracker.TrackGraph(entity, node =>
    {
        var entry = node.Entry;
        // I don't like switch case blocks !
        if (childEntity.ClientState == ObjectState.Deleted) entry.State = EntityState.Deleted;
        else if (childEntity.ClientState == ObjectState.Unchanged) entry.State = EntityState.Unchanged;
        else if (childEntity.ClientState == ObjectState.Modified) entry.State = EntityState.Modified;
        else if (childEntity.ClientState == ObjectState.Added) entry.State = EntityState.Added;
    });
