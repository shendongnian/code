	public async Task RefreshItems()
	{
		var items = await _dataService.GetDepartaments()
			.Take(1)
			.ObserveOn(SynchronizationContext.Current)
			.ToTask();
			
		Departaments.ReplaceWithRange(items);
	}
