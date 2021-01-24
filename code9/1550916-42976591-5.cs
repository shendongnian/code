    private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort port = sender as SerialPort;
        string message = "";
        if (port != null)
        {
            while(port.BytesToRead > 0)
            {
                message += port.ReadExisting();
                System.Threading.Thread.Sleep(500); // give the device time to send data
            }
        }
    }
