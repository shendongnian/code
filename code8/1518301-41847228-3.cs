    public MainForm()
    {
        InitializeComponent();
        Servers = LoadAllServers();
        timer.Interval = 1000;
        timer.Start();
        timer.Tick += Timer_Tick;
     }
     public void Timer_Tick(object sender, EventArgs e)
     {
          foreach(var s in Servers)
          {
             s.CheckState();
             DrawFish(s);
          }
     }
