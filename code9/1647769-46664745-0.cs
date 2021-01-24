    void NextWindow()
    {
        Console.WriteLine(selectedVendor.VendorName); 
        Messenger.Default.Send(new YourPayload() {WindowName = "NextWindow", Parameter = "some value..:");
    }
    ...
    public VendorSelectWindow()
    {
        InitializeComponent();
        _vm = new Biz.Invoicer.VendorSelectViewModel();
        DataContext = _vm;
        Messenger.Default.Register<YourPayload>(this, NotificationMessageReceived);
    }
    private void NotificationMessageReceived(YourPayload msg)
    {
        if (msg.WindowName == "NextWindow")
        {
            string param = msg.Parameter;
            var invoicerWindow = new InvoicerWindow();
            invoicerWindow.Show();
        }
    }
