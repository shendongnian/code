        public Timer MyTimer { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Parse(textBox1.Text);
            
            double ms = datetime.Subtract(DateTime.Now).TotalMilliseconds;
            MyTimer = new Timer();
            MyTimer.Interval = (int)ms;
            MyTimer.Tick += T_Tick;
            MyTimer.Start();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            MyTimer.Stop();
            //call your method here
        }
