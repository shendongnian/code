	public void RefreshItems()
	{
		Departments.Clear();
		_state = States.Processing();
		var items =  _dataService.GetDepartaments()
			.SubscribeOn(_schedulerProvider.Background)
			.ObserveOn(_schedulerProvider.Foreground)
			.Subscribe(
				item=> Departaments.Add(item),
				ex => _state = States.Faulted(ex),
				() => _state = States.Idle());
	}
