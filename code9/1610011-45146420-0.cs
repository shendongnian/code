        public void testc()
        {
            Timer t = new Timer();
            t.Interval = 1500;
            t.Tick += new EventHandler(timer_Tick); 
            t.Start();
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Tick");
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            testc();
        }
