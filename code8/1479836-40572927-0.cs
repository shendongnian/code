    public async void TaskBasedShow( 
        string message, 
        string caption, 
        MessageBoxButton buttons,
        MessageBoxImage image, 
        Action<MessageBoxResult> resultCallback)
    {
        var result = await Task.Run(() => MessageBox.Show(message, caption, buttons, image ) );
        resultCallback( result );
    }
