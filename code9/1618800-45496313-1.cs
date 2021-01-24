    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
    {
        this.Player = myGame.Player;
        this.Locations = myGame.Locations;
        this.RemainingTurns = myGame.RemainingTurns;
        // You need to get the value for Player.Gold
    });
