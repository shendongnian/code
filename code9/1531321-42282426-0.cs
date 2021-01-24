        public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //calculate your time and perform whatever action here
        }
