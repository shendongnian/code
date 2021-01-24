    while (true)
        {
            Socket icmpListener = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
            icmpListener.Bind(new IPEndPoint(IPAddress.Parse("564.89.556.5"), 0));
            icmpListener.IOControl(IOControlCode.ReceiveAll, new byte[] { 1, 0, 0, 0 }, new byte[] { 1, 0, 0, 0 });
            byte[] buffer = new byte[4096];
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            int bytesRead = icmpListener.ReceiveFrom(buffer, ref remoteEndPoint);
            string text = "ICMPListener received " + bytesRead + " from " + icmpListener.RemoteEndPoint;
            Console.WriteLine(text);                
        }
