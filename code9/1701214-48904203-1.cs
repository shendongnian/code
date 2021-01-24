        void StartScan()
        {
            Timer _wifiAsyncTimer = new Timer();
            _wifiAsyncTimer.Elapsed += GetWifiNetworks;
            _wifiAsyncTimer.Interval = ListenPeriodicity * 1000;
            _wifiAsyncTimer.Enabled = true;
        }
    
        private void GetWifiNetworks(object source, ElapsedEventArgs e)
        {
            var wifiNetworks = _wifiManager.GetWifiNetworks();
            if (wifiNetworks.Count > 0)
            {
                LocationInformation LocationInformation = new LocationInformation()
                {
                    LocationName = LocationName,
                    Temperature = Temperature,
                    Notes = Notes,
                    Timestamp = DateTime.Now
                };
                LocationInformations = LocationInformation.AddWifiInformation(wifiNetworks);
            }
        }
