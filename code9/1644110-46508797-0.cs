        public Form1()
        {
            InitializeComponent();
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            Client = new UdpClient(Convert.ToInt32(textBox_port.Text));
            Client.BeginReceive(DataReceived, null);
        }
        private void DataReceived(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, Convert.ToInt32(textBox_port.Text));
            byte[] data;
            try
            {
                data = Client.EndReceive(ar, ref ip);
                if (data.Length == 0)
                    return; // No more to receive
                Client.BeginReceive(DataReceived, null);
            }
            catch (ObjectDisposedException)
            {
                return; // Connection closed
            }
            // Send the data to the UI thread
            this.BeginInvoke((Action<IPEndPoint, string>)DataReceivedUI, ip, Encoding.UTF8.GetString(data));
        }
        private void DataReceivedUI(IPEndPoint endPoint, string data)
        {
            txtLog.AppendText("[" + endPoint.ToString() + "] " + data + Environment.NewLine);
        }
        private void button_stop_Click(IAsyncResult ar) // NOT WORKING!! AGH!
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, Convert.ToInt32(textBox_port.Text));
            byte[] data;
            data = Client.EndReceive(ar, ref ip);
            Client.Close();
                        
        }
