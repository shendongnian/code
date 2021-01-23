    private MainWindow mainwindow;
    
    public LogConsole() {}
    
    public LogConsole(MainWindow mainwindow)
    {
        InitializeComponent();
    
        this.mainwindow = mainwindow;
    }
    // Hide Window instead of Exiting
    protected override void OnClosing(CancelEventArgs e)
    {
        this.Hide();
        e.Cancel = true;
        base.OnClosing(e);
    }
