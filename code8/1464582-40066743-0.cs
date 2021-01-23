	public async Task RefreshItems()
	{
	    var departamentsObservable = _dataService.GetDepartaments();
	
	    await departamentsObservable.ObserveOn(SynchronizationContext.Current).Do(items =>
	    {
	        Departaments.ReplaceWithRange(items);
	    });
	}
