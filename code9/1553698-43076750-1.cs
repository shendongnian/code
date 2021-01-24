    public class WifiManager
    {
        private WiFiAdapter adapter;
        public List<WifiNetwork> Networks;
    
        pivate async Task InitializeAsync()
        {
            var access = await WiFiAdapter.RequestAccessAsync();
            if (access != WiFiAccessStatus.Allowed)
            {
                throw new WifiAdaperAccessDeniedException();
            }
            else
            {
                var result = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(WiFiAdapter.GetDeviceSelector());
                if (result.Count >= 1)
                {
                    adapter = await WiFiAdapter.FromIdAsync(result[0].Id);
                }
                else
                {
                    throw new NoWifiAdapterFoundException();
                }
            }
        }
        public async Task GetAvailableNetWorksAsync()
        {
            try
            {
                if (adapter == null)
                {
                    await InitializeAsync();
                }
                if (adapter != null)
                {
                    await adapter.ScanAsync();
                }
            }
            catch (Exception err)
            {
                throw new WifiAdaperAccessDeniedException();
            }
            Networks = new List<WifiNetwork>();
            foreach(var network in adapter.NetworkReport.AvailableNetworks)
            {
                Networks.Add(new WifiNetwork(network, adapter));
            }
        }
    }
