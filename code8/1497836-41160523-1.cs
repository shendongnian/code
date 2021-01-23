    int state = 0;
    if (this.ChangeTracker.Entries().Any(e => e.State == EntityState.Deleted))
    {
        state = 3;
    }
    else if (this.ChangeTracker.Entries().Any(e => e.State == EntityState.Modified))
    {
        state = 2;
    }
    else if (this.ChangeTracker.Entries().Any(e => e.State == EntityState.Added))
    {
        state = 1;
    }
