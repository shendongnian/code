    //ViewModel:
    void NextWindow()
    {
        //...
        int someValue = 10;
        Messenger.Default.Send(new NotificationMessage<int>(someValue, "Notification text"));
    }
    //View:
    public VendorSelectWindow()
    {
        //...
        Messenger.Default.Register<NotificationMessage<int>>(this, MessageReceived);
    }
    private void MessageReceived(NotificationMessage<int> message)
    {
        var someValue = message.Content;
        //...
    }
