    Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToShortTimeString();
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToShortTimeString();
        }
    }
