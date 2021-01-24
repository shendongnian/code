    public async Task<IViewLifetimeControl> OpenAsync(UIElement content, string title = null,
        ViewSizePreference size = ViewSizePreference.UseHalf)
    {
        this.Log($"Frame: {content}, Title: {title}, Size: {size}");
    
        var currentView = ApplicationView.GetForCurrentView();
        title = title ?? currentView.Title;
    
        var newView = CoreApplication.CreateNewView();
        var dispatcher = DispatcherEx.Create(newView.Dispatcher);
        var newControl = await dispatcher.Dispatch(async () =>
        {
            var control = ViewLifetimeControl.GetForCurrentView();
            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = title;
    
            // TODO: (Jerry)
            // control.NavigationService = nav;
    
            newWindow.Content = content;
            newWindow.Activate();
    
            await ApplicationViewSwitcher
                .TryShowAsStandaloneAsync(newAppView.Id, ViewSizePreference.Default, currentView.Id, size);
            return control;
        }).ConfigureAwait(false);
        return newControl;
    }
