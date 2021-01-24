    System.Windows.Forms.NotifyIcon notifyIcon;
    public MainWindow()
    {
        InitializeComponent();
        notifyIcon = new System.Windows.Forms.NotifyIcon();
        notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        notifyIcon.Icon = new System.Drawing.Icon("MyIcon.ico");
        notifyIcon.Visible = true;
    }
    void notifyIcon_DoubleClick(object sender, EventArgs e)
    {
        System.Windows.Application.Current.Shutdown();
        // OR
        // Environment.Exit(0)
    }
