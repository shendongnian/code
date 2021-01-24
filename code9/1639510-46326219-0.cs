    public class NavigationService: INavigationService
    {
        private NavigationPage _navPage;
        public void Initialize(NavigationPage navPage)
        {
             _navPage = navPage;
        }
        public void NavigateTo(String pageKey)
        {
            // Get Page from pageKey
            _navPage.PushAsync(page);
        }
    }
