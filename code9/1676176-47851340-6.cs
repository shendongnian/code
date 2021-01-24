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
	private AnotherPageViewModel _anotherPageViewModel;
	public AnotherPageViewModel AnotherPageViewModel
	{
		get => _anotherPageViewModel;
		set => SetProperty(ref _anotherPageViewModel, value);
	}
	public MainWindowViewModel()
	{	
		StartPageViewModel = new StartPageViewModel();
        AnotherPageViewModel = new AnotherPageViewModel();
		
		CurrentWorkspace = StartPageViewModel;
	}
	// Navigation Method
	private void NavigateToStartPage()
	{
		if (CurrentWorkspace != StartPageViewModel)
			CurrentWorkspace = StartPageViewModel;
	}
	// Navigation Method
	private void NavigateToAnotherPage()
	{
		if (CurrentWorkspace != AnotherPageViewModel)
			CurrentWorkspace = AnotherPageViewModel;
	}
	
