    string[] parameters;
    public Reservation()
    {
        Loaded += (sender, e) =>
        {
            PickupDateDisplay.Text = parameters[0];
            ReturnDateDisplay.Text = parameters[1];
        }
        
        InitializeComponent();
    }
    
    // This ctor is useless too
    // public Reservation(string pickupdate,string retdate)
    // {
    //    InitializeComponent();
    //    PickupDateDisplay.Text = pickupdate;
    //    ReturnDateDisplay.Text = retdate;
    // }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        parameters = (string[])e.Parameter;
    }
