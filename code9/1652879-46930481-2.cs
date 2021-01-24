    public override void Dispose()
    {
        var unchanged = ChangeTracker.Entries()
              .Where(x => x.EntityState == EntityState.Unchanged);
        // log your unchanged entries here
        base.Dispose();
     }
