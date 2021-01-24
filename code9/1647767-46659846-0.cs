    //ViewModel:
    void NextWindow()
    {
        //...
        int someValue = 10;
        Messenger.Default.Send(someValue);
    }
    //View:
    public VendorSelectWindow()
    {
        //...
        Messenger.Default.Register<int>(this, MessageReceived);
    }
    private void MessageReceived(int value)
    {
        //...
    }
