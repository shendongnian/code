    public class SerialPortTestClass : IDisposable
    {
        public void Dispose()
        {
            if (ComPort.IsOpen)
                Disconnect();
        }
        ...
