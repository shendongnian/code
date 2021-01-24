    public class BtCom
    {
        Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        public Task<List<string>> Scan()
        {
            var bluetoothScanTask = Task.Factory.StartNew(Scanning);
            bluetoothScanTask.Wait();
            return bluetoothScanTask;
        }
        private List<string> Scanning()
        {
            BluetoothClient client = new BluetoothClient();
            devices = client.DiscoverDevicesInRange();
            List<string> discoveredDevices = new List<string>();
            foreach (BluetoothDeviceInfo d in devices)
            {
                discoveredDevices.Add(d.DeviceName);
            }
            
            return discoveredDevices;
        }
    }
