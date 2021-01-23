    private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
    {
        var DataList = eventArgs.Advertisement.ManufacturerData;
        foreach (var temp in DataList)
        {
            var data = new byte[temp.Data.Length];
            using (var reader = DataReader.FromBuffer(temp.Data))
            {
                reader.ReadBytes(data);
            }
            var str = Encoding.ASCII.GetString(data);
        }
    }
