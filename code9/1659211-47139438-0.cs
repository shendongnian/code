    public MainWindow()
    {
        InitializeComponent();
        this.PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
    }
    
    void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if ((e.Key == Key.F2))
        { 
             //DO SOMETHING
        }
    }
