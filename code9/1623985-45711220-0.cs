                BluetoothClient client = new BluetoothClient();
                List<string> items = new List<string>();
                BluetoothDeviceInfo[] devices = client.DiscoverDevicesInRange();
                foreach (BluetoothDeviceInfo d in devices)
                {
                    items.Add(d.DeviceName);
                }
