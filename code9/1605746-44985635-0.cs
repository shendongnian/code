    public int portxt = 27001;
    public void GetOpenPort()
    {
        using (TcpClient tcpClient = new TcpClient())
        {
            try
            {
                tcpClient.Connect("192.168.1.32", portxt);
                MessageBox.Show("Port open");
            }
            catch (Exception)
            {
                MessageBox.Show("Port closed");
                randomport();
    
                txtPort.Text = portxt.ToString();  // convert your INT to a string!
            }
        }
    }
