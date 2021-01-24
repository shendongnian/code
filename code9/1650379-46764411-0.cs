[Socket][2] is thread-safe, but SocketServer **isn't**. You're writing to _buffer immediately before using it at each point of use. This is most definitely a data race in a multithreaded scenario. You need a locking mechanism around every access to shared state.
There's no point in using a field for _buffer if you overwrite it immediately before passing it along. If you need one buffer to work with, assign it once at initialization time. To avoid changing it too much, you could implement it like this:
    class SocketServer
    {
        class Transaction
        {
            public readonly byte[] Data;
            public readonly Socket Socket;
            public Transaction(byte[] data, Socket socket)
            {
                Data = data;
                Socket = socket;
            }
        }
        private readonly object _syncObj = new object();
        private readonly List<Transaction> _received = new List<Transaction>();
        //...
        
        //...
        private void AcceptCallback(IAsyncResult AR)
        {
            //...
            byte[] buffer = new byte[1024];
            socket.BeginReceive(
                buffer, 0, buffer.Length, SocketFlags.None,
                ReceiveCallback, new Transaction(buffer, socket));
            //...
        }
        private void ReceiveCallback(IAsyncResult AR)
        {
            Transaction trans = (Transaction)AR.AsyncState;
            Socket socket = trans.Socket;
            int bufferSize = socket.EndReceive(AR);
            lock (_syncObj) {
                _received.Add(trans);
            }
            //...
            byte[] buffer = new byte[1024];
            socket.BeginReceive(
                buffer, 0, buffer.Length, SocketFlags.None, 
                ReceiveCallback, new Transaction(buffer, socket));
        }
        //...
        // Call this to get all the received data. 
        // This will block ReceiveCallback until it completes.
        public byte[] GetReceivedData()
        {
            // Use longs and .LongLength instead if you expect there
            // to be more than int.MaxValue bytes between calls to this.
            int totalSize = 0;
            lock (_syncObj) {
                for (int i = 0; i < _received.Length; i++) {
                    totalSize += _received[i].Data.Length;
                }
                byte[] totalData = new byte[totalSize];
                int offset = 0;
                for (int i = 0; i < _receivedTrans.Length; i++) {
                    byte[] blockData = _receivedTrans[i].Data;
                    Buffer.BlockCopy(blockData, 0, totalData, offset, blockData.Length);
                    offset += blockData.Length;
                }
                _received.Clear();
            }
        }
    }
Alternatively you could create a thread-safe implementation of IList&lt;ArraySegment&lt;byte&gt;&gt; and use the appropriate [overloads][3], but that's out of the scope of this answer.
