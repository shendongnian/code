    private System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
    public Form1()
    {
        InitializeComponent();
        
        updateTimer.Interval = 1000;
        updateTimer.Tick += new EventHandler(update);
        updateTimer.Start();
    }
    private Random rnd = new Random();
    private void update(Object object, EventArgs eventArgs)
    {
        foreach(Tuple<int, int, double> t in list_Tuple_BuySideDepth)
        {
            t.Item1 = rnd.Next();
            t.Item2 = rnd.Next();
            t.Item3 = rnd.NextDouble();
        }
        foreach(Tuple<int, int, double> t in list_Tuple_BuySideDepth1)
        {
            t.Item1 = rnd.NextDouble();
            t.Item2 = rnd.Next();
            t.Item3 = rnd.Next();
        }
    }
    
