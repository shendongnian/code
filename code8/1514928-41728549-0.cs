    System.Windows.Threading.DispatcherTimer dispatcherTimer;
    
    public XuriNotification()
    {
        InitializeComponent();
        var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
        this.Left = desktopWorkingArea.Right - this.Width;
        this.Top = desktopWorkingArea.Bottom - this.Height;
    
        dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = new TimeSpan(0,0,2);
        dispatcherTimer.Start();
        
    }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        System.Windows.Forms.Application.Exit();
    }
