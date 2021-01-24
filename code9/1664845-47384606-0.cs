        public event EventHandler<ReceiveDataEventArgs> DataReceived = null;
        public void StartReceive()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var bytesRead = _networkStream.Read(readBuffer, 0, readBuffer.Length);
                    DataReceived?.Invoke(this, new ReceiveDataEventArgs
                    {
                        Data = bytesRead
                    });
                }
            });
            
        }
        public class ReceiveDataEventArgs : EventArgs
        {
            public byte[] Data { get; set; }
        }
