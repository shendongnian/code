	// You would more likely type this as something like ViewModelBase/ObservableObject/etc.
	private object _currentWorkspace;
	public object CurrentWorkspace
	{
		get => _currentWorkspace;
		set => SetProperty(ref _currentWorkspace, value);
	}
	
	private StartPageViewModel _startPageViewModel;
	public StartPageViewModel StartPageViewModel
	{
		get => _startPageViewModel;
		set => SetProperty(ref _startPageViewModel, value);
	}
	public MainWindowViewModel()
	{	
		StartPageViewModel = new StartPageViewModel();
		
		CurrentWorkspace = StartPageViewModel;
	}
	
