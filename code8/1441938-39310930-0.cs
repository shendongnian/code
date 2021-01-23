    public interface IAppNavigationService
    {
        bool Navigate(string pageToken, object parameter);
        void GoBack();
        bool CanGoBack();
    }
