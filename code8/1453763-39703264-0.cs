    void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort spL = (SerialPort) sender;
        byte[] buf = new byte[spL.BytesToRead];
        spL.Read(buf, 0, buf.Length);
        string data = System.Text.Encoding.Default.GetString(buf);
    }
