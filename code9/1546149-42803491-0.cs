    private void Form1_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (60 * 60 * 1000); // 60 mins
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }
    
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("The form will now be closed.", "Time Elapsed");
            this.Close();
        }
