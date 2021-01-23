            private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(10);
    
     private Timer _timer = new Timer(CallBakFunction, null, _updateInterval, _updateInterval);
            private void CallBakFunction(object state)
            {
    
            }
    
    In your case, this can be done as follows:
    
         private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(10);
         private Timer _timer ;
         public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
          _timer = new Timer(timer_Tick, null, _updateInterval, _updateInterval);
    
            NewFile();
    
        }
              private void timer_Tick(object state)
        {
            MessageBox.Show("TIMER TICKS");
    
            doc.MoveBalls(leftX, topY, width, height);
            doc.CheckCollision();
            Invalidate(true);
    
            Console.WriteLine("Moving2");
        }
