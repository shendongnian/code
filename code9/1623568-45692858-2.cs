    this.CommandBindings.Add(
      new CommandBinding(
        ApplicationCommands.Close,
        PerformClose
      )
    );
    public void PerformClose(object sender, EventArgs args)
    {
        Application.Current.Shutdown();
    }
