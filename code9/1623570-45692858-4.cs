    this.CommandBindings.Add(
      new CommandBinding(
        ApplicationCommands.Close,
        PerformClose
      )
    );
    public void PerformClose(object sender, ExecutedRoutedEventArgs args)
    {
        Application.Current.Shutdown();
    }
