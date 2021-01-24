    DispatcherTimer statusTimer = new DispatcherTimer
    {
        Interval = TimeSpan.FromSeconds(1.0)
    };
    ...
    statusTimer.Tick += async (s, e) =>
    {
        var message = status_msg.TranslateToMessage());
        await nwStream.WriteAsync(message, 0, message.Length);
        statusMsgLbl.Content = "Status Msg Sent: " + DateTime.Now.ToLongTimeString();
    };
    statusTimer.Start();
    
