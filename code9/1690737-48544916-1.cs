    private void ComTimer_Tick(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                dostuff
            }
            else if (!SerialPort.IsOpen)
            {
                ComCheckTimer.Stop();
                MessageBox.Show("Connection lost"); 
        }
    }
