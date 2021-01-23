    public class UdpBroadcastReceiver
    {
        private IBroadcastInterpreter _interpreter;
        private volatile bool _shouldReceive = true;
        /// <summary>
        /// Will listen on all ports for udp broadcasts - Will handle input with interpreter
        /// </summary>
        /// <param name="interpreter"></param>
        public UdpBroadcastReceiver(IBroadcastInterpreter interpreter)
        {
            _interpreter = interpreter;
        }
        /// <summary>
        /// Will listen for a broadcast indefinetly. Will lock up your program.
        /// Use Task.Run to start listening. Then you can use StopListening to break the loop.
        /// </summary>
        public void ListenForBroadcast(int port)
        {
            using (UdpClient client = new UdpClient(port))
            {
                IPEndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (_shouldReceive)
                {
                    byte[] receiveBuffer = client.Receive(ref senderEndPoint); // execution will stop and wait for data.
                    _interpreter?.HandleBroadcast(receiveBuffer);
                }
            }
        }
        /// <summary>
        /// Breaks the while loop in ListenForBroadcast
        /// </summary>
        public void StopListening()
        {
            _shouldReceive = false;
        }
    }
