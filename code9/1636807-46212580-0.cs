    public class CheckInternet
    {
        public CheckInternet()
        {
            Timer t1 = new Timer();
            t1.Interval = 1000;
            t1.Tick += T1_Tick;
            t1.Start();
        }
        private void T1_Tick(object sender, EventArgs e)
        {
            var ping = new System.Net.NetworkInformation.Ping();
            var result = ping.Send("www.google.com");
            if (result.Status != System.Net.NetworkInformation.IPStatus.Success)
            {
                // Your code to reconnect here
            }
        }
        public event EventHandler CheckConnectivity;
        private void OnCheckConnectivity()
        {
            CheckConnectivity?.Invoke(this, new EventArgs());
        }
    }
    
