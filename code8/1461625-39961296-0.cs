    public class RepositoriesPageViewModel : BindableBase
    {
      private INavigationService _navigationService;
      private readonly Session _session;
      public NotifyTask<ObservableCollection<RepositoryModel>> Repositories { get; }
      private readonly RepositoriesManager _repositoriesManager;
      public RepositoriesPageViewModel(INavigationService navigationService, ISecuredDataProvider securedDataProvider)
      {
        _navigationService = navigationService;
        var token = securedDataProvider.Retreive(ConstantsService.ProviderName, UserManager.GetLastUser());
        _session = new Session(UserManager.GetLastUser(), token.Properties.First().Value);
        var navigationParameters = new NavigationParameters { { "Session", _session } };
        _repositoriesManager = new RepositoriesManager(_session);
        Repositories = NotifyTask.Create(GetRepositoriesAsync());
      }
    }
    private async Task<ObservableCollection<RepositoryModel>> GetRepositoriesAsync()
    {
      return new ObservableCollection<RepositoryModel>(await _repositoriesManager.GetRepositoriesAsync());
    }
