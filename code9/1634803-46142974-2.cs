    public MyView()
    {
        Debug.WriteLine("InitializeComponent -Start");
        InitializeComponent();
        Debug.WriteLine("InitializeComponent -End");
        //InitializeControl();
        this.headText.TextColor = HeadTextColor;
    }
