        TimeSpan testTime = DateTime.Now.TimeOfDay;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Start();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            testTime = testTime.Subtract(new TimeSpan(0, 0, 1));
            lblTime.Text = testTime.ToString("hh\\:mm\\:ss");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            testTime = testTime.Add(new TimeSpan(1, 0, 0));
            lblTime.Text = testTime.ToString("hh\\:mm\\:ss");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            testTime = testTime.Add(new TimeSpan(0, 1, 0));
            lblTime.Text = testTime.ToString("hh\\:mm\\:ss");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            testTime = testTime.Add(new TimeSpan(0, 0, 1));
            lblTime.Text = testTime.ToString("hh\\:mm\\:ss");
        }
