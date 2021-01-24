	public ICommand ShowDialogCommand { get; private set; }
	ShowDialogCommand = new MvxCommand<MyType>(ShowMyVM);
	private void ShowMyVM(MyType e)
	{
		if (e != null)
			ShowViewModel<SingleClientViewModel>(e);
		else
		{
			//handle case where your parameter is null
		}
	}
