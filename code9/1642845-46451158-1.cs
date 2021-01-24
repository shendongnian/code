    public static void DataReceivedHandler2(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        Console.Write("RFID: " + indata + Environment.NewLine);
        Console.Write("GPS latest Data: " + indata_GPS  + Environment.NewLine);
    }
