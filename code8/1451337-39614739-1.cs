    class UdpBroadcaster
    {
        private int _port;
        private bool shouldRun = true;
        public UdpBroadcaster(int port)
        {
            _port = port;
        }
        public void Stop()
        {
            shouldRun = false;
        }
        public void Start()
        {
            Trace.TraceInformation("Entered start method");
            Task.Run(() =>
                    {
                        Trace.TraceInformation("Started task");
                        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Broadcast, _port);
                        using (UdpClient client = new UdpClient())
                        {
                            Trace.TraceInformation("Entered using statement");
                            client.EnableBroadcast = true;
                            while(shouldRun)
                            {
                                Trace.TraceInformation("Started while loop");
                                byte[] data = Encoding.ASCII.GetBytes(DateTime.Now.ToString(new CultureInfo("da-dk")));
                                client.Send(data, data.Length, serverEndPoint);
                                Trace.TraceInformation("waiting 5 seconds");
                                Thread.Sleep(5 * 1000);
                            }
                        }
                    });
        }
    }
