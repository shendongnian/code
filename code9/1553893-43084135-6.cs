        private int GetMaxBandwidth()
        {
            int maxBandwidth = 0;
            NetworkInterface[] networkIntrInterfaces  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var networkInterface in networkIntrInterfaces)
            {
                IPv4InterfaceStatistics interfaceStats = networkInterface.GetIPv4Statistics();
                int bytesSentSpeed = (int)(interfaceStats.BytesSent);
                int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived);
                if (bytesSentSpeed + bytesReceivedSpeed > maxBandwidth)
                {
                    maxBandwidth = bytesSentSpeed + bytesReceivedSpeed;
                }
            }
		}
