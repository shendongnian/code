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
        for (int i = 0; i < list_Tuple_BuySideDepth.Count; i++)
        {
            list_Tuple_BuySideDepth[i] = new Tuple<int, int, double>(rnd.Next(), rnd.Next(), rnd.NextDouble());
        }
        for (int i = 0; i < list_Tuple_BuySideDepth1.Count; i++)
        {
            list_Tuple_BuySideDepth1[i] = new Tuple<double, int, int>(rnd.NextDouble(), rnd.Next(), rnd.Next());
        }
    }
    
