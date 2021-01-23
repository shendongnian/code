	public void UpdateRepack(RepackRequest repack)
	{
		RepackRequest fromDatabase = _uow.RepackService.Get(repack.ID);
		// Set current values to new values.
		_context.SetValues(fromDatabase, repack);
		_context.Save(); //_context.SaveChanges() called inside here
	}
	
	public void SetValues<T>(T entity, T currentEntity) where T : class
	{
		var entry = Entry(entity);
		entry.CurrentValues.SetValues(currentEntity);
	}
	
