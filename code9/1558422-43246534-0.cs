	public class MyPageViewModel
	{
		INavigationService _navigationService { get; }
		public MyPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
		}
		public DelegateCommand<string> NavigateCommand { get; }
		public async void OnNavigateCommandExecuted(string path) =>
			await _navigationService.NavigateAsync(path);
	}
