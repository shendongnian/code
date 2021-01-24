    public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
    {
        // TODO: add your long-running task here    
        var protocolArgs = args as ProtocolActivatedEventArgs;
        if (protocolArgs != null && protocolArgs.Uri != null)
        {
            Frame newframe = new Frame();
            newframe.Navigate(typeof(Views.DetailPage));
            Window.Current.Content = newframe; // protocol activation
        }
        else
        {
            await NavigationService.NavigateAsync(typeof(Views.MainPage)); // regular activation
        }
    }
