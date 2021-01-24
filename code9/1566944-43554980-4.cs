        private void Form1_Load(object sender, EventArgs e)
        {
            tm.Interval = 1000;
            tm.Tick += RunEvent;
            tm.Start();
        }
        private void RunEvent(object sender, System.EventArgs e)
        {
            var selectedTime = selectingtime();
            label1.Text = DateTime.Now.ToLongTimeString();
            DateTime dateT = DateTime.Now; // created datetime
            if (dateT.ToString("hh:mm tt") == selectedTime) // condition where dateT.ToString is equal to selectedtime 
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Please work"); // expected output whenever dateT.ToString is equal to selected time.
            }
        }
        private string selectingtime()
        {
            DateTime time;
            string timeFormat = string.Format("{0}:{1} {2}", textBox1.Text, textBox2.Text, textBox3.Text);
            DateTime.TryParse(timeFormat, out time);
            return time.ToString("hh:mm tt");
        }
 
