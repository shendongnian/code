    private void StartBtn_Click(object sender, EventArgs e)
    {
        Thread listenerThread = new Thread(listen);
        listenerThread.Start();
    }
    void listen(object State)
    {
        try
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.1.31"), 60000);
            listener.Start();
            this.BeginInvoke((Action)(() => {StatusAndMsg.Text = "lisening for connection requests";}));
            
            while (true)
            {
                this.BeginInvoke((Action)(() => {StatusAndMsg.Text = "lisening for connection requests";}));
                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                string s = null;
                while (s != "Exit")
                {
                    this.BeginInvoke((Action)(() => {StatusAndMsg.Text = "you can now start typing";}));
                    sw.WriteLine(textBox1.Text);
                    sw.Flush();
                    this.BeginInvoke((Action)(() => {StatusAndMsg.Text = "client : " + sr.ReadLine();}));
                    
                }
                sw.Close();
                sr.Close();
                client.Close();
            }
        }catch (Exception b)
        {
            this.BeginInvoke((Action)(() => {StatusAndMsg.Text = "error : " + b;}));
            
        }
    }
