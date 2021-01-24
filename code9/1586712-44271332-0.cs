    class UdpHandler {
        public UdpHandler(int portNo) {
            Thread t = new Thread(ListenThread);
            t.IsBackground = true;
            t.Start(portNo);
        }
        public void ListenThread(object portNo) {
            UdpClient client = new UdpClient { ExclusiveAddressUse = false };
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, (int)port);
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;
            client.Client.Bind(localEp);
            while (true) {
                byte[] data = client.Receive(ref localEp);
                DataReceived(data);
            }
        }
        private void DataReceived(byte[] rawData) {
            // Handle the received data
        }
    }
