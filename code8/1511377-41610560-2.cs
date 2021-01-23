       public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            System.Windows.Forms.Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_Tick);
            //Console.WriteLine("STARTING TIMER");
            timer.Start();
    
        }
