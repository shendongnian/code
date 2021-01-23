        public sealed partial class MainPage : Page
        {
            ConnectingObject conn;
            public MainPage()
            {
                this.InitializeComponent();
                conn = new ConnectingObject();
            }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BluetoothConnect));
        }
        public void cancelConnection()
        {
            conn.Dispose();
        }
    
        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            conn.Dispose();
        }
    
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            conn.Initialize();
        }
    }
    
    public class ConnectingObject : IDisposable
    {
        GattCharacteristic hrMonitorCharacteristics;
        GattDeviceService firstHeartRateMonitorService;
    
        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
    
            if (disposing)
            {
                // Free any other managed objects here.
                //
                if (firstHeartRateMonitorService != null)
                {
                    firstHeartRateMonitorService.Dispose();
                    firstHeartRateMonitorService = null;
                }
                if (hrMonitorCharacteristics != null)
                {
                    hrMonitorCharacteristics.Service.Dispose();
                    hrMonitorCharacteristics = null;
                }
            }
    
            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    
        //~HRGATTConnect()
        //{
        //    Dispose(false);
        //}
        public async void Initialize()
        {
            try
            {
                var heartrateServices = await Windows.Devices.Enumeration
                    .DeviceInformation.FindAllAsync(GattDeviceService
                        .GetDeviceSelectorFromUuid(
                            GattServiceUuids.HeartRate),
                    null);
    
                firstHeartRateMonitorService = await
                    GattDeviceService.FromIdAsync(heartrateServices[0].Id);
    
                Debug.WriteLine("serviceName:  " + heartrateServices[0].Name);
    
                hrMonitorCharacteristics =
                    firstHeartRateMonitorService.GetCharacteristics(
                        GattCharacteristicUuids.HeartRateMeasurement)[0];
    
                hrMonitorCharacteristics.ValueChanged += hrMeasurementChanged;
    
                await hrMonitorCharacteristics
                        .WriteClientCharacteristicConfigurationDescriptorAsync(
                            GattClientCharacteristicConfigurationDescriptorValue.Notify);
    
                disposed = false;
    
            }
            catch (Exception e)
            {
    
            }
        }
        void hrMeasurementChanged(GattCharacteristic sender, GattValueChangedEventArgs eventArgs)
        {
            try
            {
                byte[] hrData = new byte[eventArgs.CharacteristicValue.Length];
                Windows.Storage.Streams.DataReader.FromBuffer(
                    eventArgs.CharacteristicValue).ReadBytes(hrData);
                //data_processing(hrData);
            }
            catch (Exception e)
            {
    
            }
        }
    
    }
