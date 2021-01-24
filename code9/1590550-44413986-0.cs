    public class DataInput
    {
        public event Action<string> DataReceived;
        ...
        public void Close()
        {
            if(mySerialPort.IsOpen)
            {
                mySerialPort.Close();
            }
        }
    }
