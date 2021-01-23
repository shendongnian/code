	public RelayCommand MyCommand { get; set; }
	public void SomeOtherMethod()
	{
		if (MyCommand.CanExecute())
		{
			MyCommand.Execute();
		}
	}
