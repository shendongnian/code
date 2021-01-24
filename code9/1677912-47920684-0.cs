    static void senddata() {
        // send message every 100 ms
        while (true) {
            // wrap in using
            using (UdpClient udpClient = new UdpClient()) {
                // loopback
                udpClient.Connect(IPAddress.Loopback, 9999);
                Byte[] senddata1 = Encoding.ASCII.GetBytes("Hello World");
                udpClient.Send(senddata1, senddata1.Length);
            }
            Thread.Sleep(100);
        }
    }
    static void Main(string[] args) {
        // run sending in background
        Task.Run(() => senddata());
        try {
            // wrap in using
            using (UdpClient udpClient = new UdpClient(9999)) {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                // move while loop here
                while (true) {
                    // this blocks until message is received
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine(returnData);
                }
            }
        }
        catch (Exception e) {
            // do something meaningful
        }
    }
