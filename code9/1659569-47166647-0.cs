    private List<IPAddress> GetEndpoints()
        {
            List<IPAddress> AddressList = new List<IPAddress>();
            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface I in Interfaces)
            {
                if ((I.NetworkInterfaceType == NetworkInterfaceType.Ethernet || I.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && I.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (var Unicast in I.GetIPProperties().UnicastAddresses)
                    {
                        if (Unicast.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            AddressList.Add(Unicast.Address);
                        }
                    }
                }
            }
            return AddressList;
        }
