        using Windows.Devices.Bluetooth.Advertisement;
        namespace BeaconExample
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var watcher = new BluetoothLEAdvertisementWatcher();
                    watcher.Received += Watcher_Received;
                    watcher.Start();
                }
                private static void Watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
                {
                    Console.WriteLine(args.BluetoothAddress.ToString("x") + ";" + args.RawSignalStrengthInDBm);
                }
            }
        }
     
