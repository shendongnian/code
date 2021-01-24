        public class MySocket : System.Net.Sockets.Socket, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private bool _connected = false;
            private Thread _pollingThread;
            public new bool Connected
            {
                get { return _connected; }
                private set { _connected = value; NotifyPropertyChanged(); }
            }
            public MySocket() : base (System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
            {
                _pollingThread = new Thread(PollingThread);
                _pollingThread.IsBackground = true;
                _pollingThread.Start();
            }
            protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private void PollingThread()
            {
                while (true) {
                    Thread.Sleep(500);
                    if (base.Connected != Connected) Connected = base.Connected;
                }
            }            
        }
