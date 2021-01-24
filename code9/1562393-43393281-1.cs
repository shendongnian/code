    public void HandleSerialData(byte[] respBuffer, SerialPort comport)
    {
        StringBuilder hex = new StringBuilder(respBuffer.Length * 2);
        foreach (byte b in respBuffer)
        hex.AppendFormat("{0:x2}", b);
        string hex2 = hex.ToString();
        hex2 = hex2.Substring(22, 8);
        //EnOcean_Label.Dispatcher.CheckAccess();
        Dispatcher.BeginInvoke((Action)(()=>{EnOcean_Label.Content = hex2;}));
    }
