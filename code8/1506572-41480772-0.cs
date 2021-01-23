    _context.ChangeTracker.TrackGraph(rootEntity, node => 
    { 
        node.Entry.State = n.Entry.IsKeySet ? 
            EntityState.Modified : 
            EntityState.Added; 
    });
