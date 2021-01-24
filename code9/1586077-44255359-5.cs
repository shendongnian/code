    Socket icmpListener = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
            icmpListener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80));
            icmpListener.IOControl(IOControlCode.ReceiveAll, new byte[] { 1, 0, 0, 0 }, new byte[] { 1, 0, 0, 0 });
            while (true)
            {
                byte[] buffer = new byte[4096];
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                int bytesRead = icmpListener.ReceiveFrom(buffer, ref remoteEndPoint);
                Console.WriteLine("ICMPListener received " + bytesRead + " from " + remoteEndPoint);
            }
