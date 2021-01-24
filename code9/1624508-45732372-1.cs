    public void sendStatusMessage()
    {
        sendMessage(status_msg.TranslateToMessage());
        var text =  "Status Msg Sent: " + DateTime.Now.ToLongTimeString();
        Dispatcher.Invoke(() => statusMsgLbl.Content = text);
