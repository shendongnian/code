        private readonly Dispatcher _uiDispatcher;
        public MainWindow()
        {
            InitializeComponent();
            _uiDispatcher = Dispatcher.CurrentDispatcher;
            var dataContext = new X_Y();
            X_values.DataContext = dataContext;
            Y_values.DataContext = dataContext;
            Task.Factory.StartNew(UDP_listening_PI1);
        }
        public void UDP_listening_PI1()
        {
            UdpClient listener = new UdpClient(48911);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, (48911));
            bool done = false;
            try
            {
                while (!done)
                {
                    byte[] pdata = listener.Receive(ref groupEP);
                    string price = Encoding.ASCII.GetString(pdata);
                    int Rawdata1 = int.Parse(price);
                    Rawdata_str1 = Rawdata1.ToString();
                    UpdateXY(Rawdata_str1);
                }
            }
            finally
            {
                listener.Close();
            }
        }
        private void UpdateXY(string rawData)
        {
            if (!_uiDispatcher.CheckAccess())
            {
                _uiDispatcher.BeginInvoke(DispatcherPriority.Normal, () => { UpdateXY(rawData); });
                return;
            }
            dataContext.X = rawData;
            dataContext.Y = rawData;
            //Need to raise property changed event.
        }
