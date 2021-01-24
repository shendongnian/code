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
            int.TryParse(textBox1.Text, out hourt);//textbox for hour
            int.TryParse(textBox2.Text, out minutet);// textbox for minute
            hourformatt = textBox3.Text;// textbox for AM or PM
            return hourt + ":" + minutet + " " + hourformatt; // example 05:31 PM
        }
 
