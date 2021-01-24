    public void UpdateBackButton(Frane frame)
    {
        bool canGoBack = (frame?.CanGoBack ?? false);
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = canGoBack
            ? AppViewBackButtonVisibility.Visible
            : AppViewBackButtonVisibility.Collapsed;
    }
