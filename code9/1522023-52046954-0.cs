    public sealed partial class MainPage : Page
    {
        Windows.Devices.Bluetooth.Advertisement.BluetoothLEAdvertisementWatcher advertisementWatcher;
        public MainPage()
        {
            this.InitializeComponent();
            advertisementWatcher = new Windows.Devices.Bluetooth.Advertisement.BluetoothLEAdvertisementWatcher();
            advertisementWatcher.ScanningMode = Windows.Devices.Bluetooth.Advertisement.BluetoothLEScanningMode.Passive;
            advertisementWatcher.Received += AdvertisementWatcher_Received;
            advertisementWatcher.Start();
        }
        private void AdvertisementWatcher_Received(Windows.Devices.Bluetooth.Advertisement.BluetoothLEAdvertisementWatcher sender, Windows.Devices.Bluetooth.Advertisement.BluetoothLEAdvertisementReceivedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Address: {0:X}", args.BluetoothAddress);
        }
    }
