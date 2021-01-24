    private DeltaMotor M2 { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        M2 = new DeltaMotor();
        M2.Card.Set8255();  
        M2.Stop();
    }
