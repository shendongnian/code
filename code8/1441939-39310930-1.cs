    public class AppNavigationService : IAppNavigationService
    {
       private readonly INavigationService _nav;
    
       public AppNavigationService( INavigationService navigationService )
       {
          _nav = navigationService;
       } 
       
       public bool Navigate(string pageToken, object parameter) => 
          _nav.Navigate( pageToken, parameter );
    
       public void GoBack()
       {
          _nav.GoBack();
       }
    
       public bool CanGoBack() => _nav.CanGoBack();
    }
