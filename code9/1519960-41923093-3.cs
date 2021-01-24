    public override int SaveChanges()
    {
	    var currentTime = DateTime.Now;
	    var changed = ChangeTracker.Entries<ConcurrencyTracker>().Where(c => c.State != EntityState.Unchanged);
	    if (changed != null)
	    {
		    foreach (var item in changed)
		    {
			    item.Entity.LastChangeTime = currentTime;
		    }
	    }
        return base.SaveChanges();
    }
