    this.WhenActivated(disposables =>
	{
		this.WhenAnyValue(view => view.ViewModel.LoadData)
			.Select(cmd => Unit.Default)
			.InvokeCommand(this.ViewModel.LoadData)
            .DisposeWith(disposables);                     
	});
