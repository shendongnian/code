    private static void myPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        Console.Write("Bytes to read : ");
        Console.WriteLine(sp.BytesToRead);
        string data = sp.ReadExisting();
        Console.WriteLine(data);
    }
