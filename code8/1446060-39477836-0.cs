    SerialPort Port = new SerialPort("COM4", 9600);
    Port.Open();
    if (Port.IsOpen)
    {
         Port.Write("#");
         Port.Write("Test#");
         System.Threading.Thread.Sleep(1000);
         String Read = Port.ReadExisting();
         Port.Close();
    }
