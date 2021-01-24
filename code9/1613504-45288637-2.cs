    public TEntity Find(params object[] keyValues)
    {
      this.InternalContext.ObjectContext.AsyncMonitor.EnsureNotEntered();
      this.InternalContext.DetectChanges(false);
      // ...code
    }
