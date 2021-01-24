    CoreApplicationViewTitleBar titleBar = CoreApplication.GetCurrentView().TitleBar;
    titleBar.LayoutMetricsChanged += TitleBar_LayoutMetricsChanged;
    private void TitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
    {
        AppTitle.Margin = new Thickness(CoreApplication.GetCurrentView().TitleBar.SystemOverlayLeftInset + 12, 8, 0, 0);
    }
