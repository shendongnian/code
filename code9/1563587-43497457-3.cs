    private async void ThemeManager_ThemeChanged(Utils.ThemeManager theme)
    {
        await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            ((SolidColorBrush)Application.Current.Resources["BackgroundBrush"]).Color = theme.HighAccentColorBrush;
        });
    }
