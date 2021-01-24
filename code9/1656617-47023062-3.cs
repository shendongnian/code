    Button1Command = new RelayCommand(() => ExecuteButtonCommand());
    ....
    private void ExecuteButtonCommand()
    {
        Messenger.Default.Send<ChangeBackgroundMessage>(new ChangeBackgroundMessage { TheColor = Brushes.Red } );
    } 
 
