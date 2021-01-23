    System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
    public frmDOOR()
    {
        InitializeComponent();
        aTimer.Tick+= new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 1000;
        aTimer.Enabled = true;           
    }
    
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {                
        this.Close();
        // or even shorter just Close();
        frmUser regform = new frmUser();
        regform.StartPosition = FormStartPosition.CenterParent;            
        regform.ShowDialog();
    }
