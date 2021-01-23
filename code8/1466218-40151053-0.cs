    public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
    {
        AdditionalKinds cause = DetermineStartCause(args);
        if (cause == AdditionalKinds.SecondaryTile)
        {
            LaunchActivatedEventArgs eventArgs = args as LaunchActivatedEventArgs;
            NavigationService.Navigate(typeof (DetailPage), eventArgs.Arguments);
        }
        else
        {
            NavigationService.Navigate(typeof (MainPage));
        }
 
        return Task.FromResult<object>(null);
    }
