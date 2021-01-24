    public MainWindow()
    {
        InitializeComponent();
        Loaded += (s, e) =>
        {
            Process p = Process.Start("notepad.exe");
            p.WaitForInputIdle(); // Allow the process to open it's window
            SetParent(p.MainWindowHandle, new System.Windows.Interop.WindowInteropHelper(this).Handle);
        };
    }
