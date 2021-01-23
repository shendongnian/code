    _context.ChangeTracker.TrackGraph(entity, node =>
    {
        var entry = node.Entry;
        // cast to my own BaseEntity
        var childEntity = (BaseEntity)node.Entry.Entity;
        // If entity is new, it must be added whatever the client state
        if (childEntity.IsNew) entry.State = EntityState.Added;
        // then client state is mapped
        else if (childEntity.ClientState == ObjectState.Deleted) entry.State = EntityState.Deleted;
        else if (childEntity.ClientState == ObjectState.Unchanged) entry.State = EntityState.Unchanged;
        else if (childEntity.ClientState == ObjectState.Modified) entry.State = EntityState.Modified;
        else if (childEntity.ClientState == ObjectState.Added) entry.State = EntityState.Added;
    });
