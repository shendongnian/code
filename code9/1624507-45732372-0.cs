    public void sendStatusMessage()
    {
        sendMessage(status_msg.TranslateToMessage());
        var text =  "Status Msg Sent: " + DateTime.Now.ToLongTimeString();
        Dispatcher.Invoke(DispatcherPriority.Normal, (System.Action)delegate //change the priority so you can use UI
        {
            statusMsgLbl.Content = text;
        });
    }
