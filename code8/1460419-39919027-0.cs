    public class Program
    {
        // call Foo write with "show running-config"
    }
    public class Foo
    {
        private TcpClient _client;
        private ConcurrentQueue<string> _responses;
        private Task _continualRead;
        private CancellationTokenSource _readCancellation;
        public Foo()
        {
            this._responses = new ConcurrentQueue<string>();
            this._readCancellation = new CancellationTokenSource();
            this._continualRead = Task.Factory.StartNew(this.ContinualReadOperation, this._readCancellation.Token, this._readCancellation.Token);
        }
        public async Task<bool> Connect(string ip)
        {
            this._client = new TcpClient
            {
                ReceiveTimeout = 3, // probably shouldn't be 3ms.
                SendTimeout = 3     // ^
            };
            int timeout = 1000;
            return await this.AwaitTimeoutTask(this._client.ConnectAsync(ip, 23), timeout);
        }
        public async void StreamWrite(string message)
        {
            var messageBytes = Encoding.ASCII.GetBytes(message);
            var stream = this._client.GetStream();
            if (await this.AwaitTimeoutTask(stream.WriteAsync(messageBytes, 0, messageBytes.Length), 1000))
            {
                //write success
            }
            else
            {
                //write failure.
            }
        }
        public async void ContinualReadOperation(object state)
        {
            var token = (CancellationToken)state;
            var stream = this._client.GetStream();
            var byteBuffer = new byte[4096];
            while (!token.IsCancellationRequested)
            {
                int bytesLastRead = 0;
                if (stream.DataAvailable)
                {
                    bytesLastRead = await stream.ReadAsync(byteBuffer, 0, byteBuffer.Length, token);
                }
                if (bytesLastRead > 0)
                {
                    var response = Encoding.ASCII.GetString(byteBuffer, 0, bytesLastRead);
                    this._responses.Enqueue(response);
                }
            }
        }
        private async Task<bool> AwaitTimeoutTask(Task task, int timeout)
        {
            return await Task.WhenAny(task, Task.Delay(timeout)) == task;
        }
        public void GetResponses()
        {
            //Do a TryDequeue etc... on this._responses.
        }
    }
