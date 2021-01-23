        int _clientCount = 0;
        bool _stopCapture = false;
        Nequeo.Net.UdpSingleServer _udpsingle = null;
        Nequeo.Media.FFmpeg.MediaDemux _demux = null;
        ConcurrentDictionary<IPEndPoint, Nequeo.Net.Sockets.IUdpSingleServer> _clients = null;
        private void StartServer()
        {
            // Create the server endpoint.
            Nequeo.Net.Sockets.MultiEndpointModel[] model = new Nequeo.Net.Sockets.MultiEndpointModel[]
                {
                    // None secure.
                    new Nequeo.Net.Sockets.MultiEndpointModel()
                    {
                        Port = 514,
                        Addresses = new System.Net.IPAddress[]
                        {
                            System.Net.IPAddress.IPv6Any,
                            System.Net.IPAddress.Any
                        }
                    },
                };
            if (_udpsingle == null)
            {
                // Create the UDP server.
                _udpsingle = new Nequeo.Net.UdpSingleServer(model);
                _udpsingle.OnContext += UDP_Single;
            }
            // Create the client collection.
            _clients = new ConcurrentDictionary<IPEndPoint, Nequeo.Net.Sockets.IUdpSingleServer>();
            _demux = new Nequeo.Media.FFmpeg.MediaDemux();
            // Start the server.
            _udpsingle.Start();
            _clientCount = 0;
            _stopCapture = false;
            // Start the capture process.
            CaptureAndSend();
        }
