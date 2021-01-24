    this.CommandBindings.Add(new CommandBinding(Commands.EditRow, EditButtonClicked));
    private void EditButtonClicked(object sender, ExecutedRoutedEventArgs args) 
    {
        var button = args.OriginalSource;
        // do what you need here
    }
