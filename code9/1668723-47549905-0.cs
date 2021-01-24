        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 4000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string Address = "8.8.8.8";
            PingHost(Address);
        }
        public  bool PingHost(string Address)
        {
            bool Canping = false;
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(Address);              
                label6.Text = reply.Status.ToString();
                label6.ForeColor = Color.Blue;
            }
            catch (PingException e)
            {
                label6.Text = e.ToString();
                label6.ForeColor = Color.Red;
            }
            return Canping;
        }
