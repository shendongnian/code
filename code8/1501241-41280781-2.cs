    public MainWindow()
    {
        InitializeComponent();
    
        // Start the Log Console
        StartLogConsole();
    }
    
    // Method
    public void StartLogConsole()
    {
        MainWindow mainwindow = this;
        console = new LogConsole(mainwindow);
        // window position
        console.Left = this.Left + 0;
        console.Top = this.Top + 0;
        console.Hide();
    }
    LogConsole console = new LogConsole();
