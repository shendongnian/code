    public Page1()
    {
        InitializeComponent();
        this.Loaded += Page1_Loaded;
    }
    private void Page1_Loaded(object sender, RoutedEventArgs e)
    {
        //Your code
        this.Loaded -= Page1_Loaded;
    }
