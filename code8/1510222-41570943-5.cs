    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Task.Run(() => mySerialDevice1.WriteData(data1));
        Task.Run(() => mySerialDevice1.WriteData(data2));
    }
    
    public class SerialDevice
    {
        public Port Port { get; set; }
        public object _LockWriteData = new object();
        public void WriteData(string data)
        {
            lock(_LockWriteData)
            {
                Port.WriteLine(data);
            }
        }
    }
