    public virtual DbContext CreateInstance()
    {
    	dbContext = _activator == null ? null : _activator();
    	dbContext.InternalContext.ApplyContextInfo(this);
    	return dbContext;
    }
