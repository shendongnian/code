    private DeltaMotor M2;
    public MainWindow()
    {
        InitializeComponent();
        M2 = new DeltaMotor();
        M2.Card.Set8255();  
        M2.Stop();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        M2.Move(1);
    }
