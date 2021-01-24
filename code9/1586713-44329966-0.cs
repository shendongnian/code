            Socket ReceiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            EndPoint DefaultIPEndpoint = new IPEndPoint(IPAddress.Parse("10.0.2.0"), 0);
            ReceiveSocket.ReceiveTimeout = 5000;
            ReceiveSocket.Bind(DefaultIPEndpoint);
            ReceiveSocket.IOControl(IOControlCode.ReceiveAll, new byte[4] { 1, 0, 0, 0 }, null);
            while (true)
            {
                byte[] ReceiveBuffer = new byte[512];
                int ByteCount = 0;
                ByteCount = ReceiveSocket.ReceiveFrom(ReceiveBuffer, ref DefaultIPEndpoint);
                // Handle packets ...
            }
