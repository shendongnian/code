        private void Connect()
        {
            // Create the client.
            IPEndPoint ee = new IPEndPoint(IPAddress.Any, 541);
            UdpClient u = new UdpClient(ee);
            // Create the state.
            UdpState s = new UdpState();
            s.e = ee;
            s.u = u;
            // Connect to the server.
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 514);
            u.Connect("localhost", 514);
            // Start the begin receive callback.
            u.BeginReceive(new AsyncCallback(ReceiveCallback), s);
            // Send a connect request.
            byte[] connect = System.Text.Encoding.Default.GetBytes("connect");
            u.Send(connect, connect.Length);
        }
        public static void ReceiveCallback(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
            IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;
            Byte[] receiveBytes = u.EndReceive(ar, ref e);
            string receiveString = Encoding.ASCII.GetString(receiveBytes);
            u.BeginReceive(new AsyncCallback(ReceiveCallback), (UdpState)(ar.AsyncState));
        }
