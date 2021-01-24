    private DeltaMotor _m2;
    
    public MainWindow()
    {
        InitializeComponent();
        _m2 = new DeltaMotor();
        _m2.Card.Set8255();  
        _m2.Stop();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _m2.Move(1);
    }
