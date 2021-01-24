    public void NavigateToNewWorkPage()
    {
        _view.NavigationService?.Navigate(new WorkPage());
        while(_view.NavigationService?.CanGoBack == true)
        {
            _view.NavigationService?.RemoveBackEntry();
        }
    }
