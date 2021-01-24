    protected override async void OnInitialized()
    {
        try
        {
            TaskScheduler.UnobservedTaskException += (sender, e) => {
                Logger.Log(e.Exception.ToString(), Category.Exception, Priority.High);
            };
            await NavigationService.NavigateAsync("LaunchPage");
        }
        catch(Exception e)
        {
            Logger.Log(e.Exception.ToString(), Category.Exception, Priority.High);
        }
    }
