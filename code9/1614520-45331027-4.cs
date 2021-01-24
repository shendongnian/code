        private void button1_Click(object sender, EventArgs e)
        {
            if(!mytimer.Enabled) // this will prevent a double start
            {
                starttimer = true;
                mytimer.Start();
            }
        }
