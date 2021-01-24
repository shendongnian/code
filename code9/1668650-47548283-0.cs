        public Form1()
        {
            InitializeComponent();
            timer.Interval = 15;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBoxBall.Left += 5;
        }
