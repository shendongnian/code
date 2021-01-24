    internal class SerialListener : Listener
    {
        private SerialPort sp;
        private ConnectionInfo _connection;
        private Timer _listenerTimer;
        private bool should_exit = false;
        private bool busy = false;
		ConcurrentQueue<byte> fifo_peekonly = null;
		BlockingCollection<byte> fifo_queue = null;
        public SerialListener(ConnectionInfo connection)
            : base(connection)
        {
            _connection = connection;
            InitSerialConnection();
        }
        private void InitSerialConnection()
        {
            sp = new SerialPort(_connection.ifname_ip);
            sp.BaudRate = _connection.baudrate_port;
            sp.Parity = _connection.parity;
            sp.DataBits = _connection.charactersize;
            sp.StopBits = _connection.stopbits;
            sp.Handshake = _connection.flowcontrol;
            sp.DtrEnable = true;
            sp.ReadTimeout = 100;
            sp.Open();
			fifo_peekonly = new ConcurrentQueue<byte>();
			fifo_queue = new BlockingCollection<byte>(fifo_peekonly);
			sp.DataReceived += (sender, e) => 
			{ 
				byte[] buffer = new byte[sp.BytesToRead];
				if (!sp.IsOpen)
				{
					throw new System.InvalidOperationException("Serial port is closed.");
				}
				sp.Read(buffer,0,sp.BytesToRead);
				foreach (var b in buffer)
					fifo_queue.Add(b);
			};
        }
        public override byte GetByteFromDevice()
        {
			byte b;
			b = fifo_queue.Take();
			return b;
        }
		public override byte PeekByteFromDevice ()
		{
			byte b;
			bool peeked = false;
			do {
				peeked = fifo_peekonly.TryPeek(out b);
				if (!peeked)
					Thread.Sleep(100);
			} while (!peeked);
			return b;
		}
        public override void Close()
        {
            base.Close();
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            Thread.Sleep(3000);
            sp.Close();
        }
    }
