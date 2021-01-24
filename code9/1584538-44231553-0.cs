    using System;
    using System.Diagnostics;
    using Windows.Devices.Bluetooth;
    using Windows.Devices.Bluetooth.GenericAttributeProfile;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {    
       public sealed partial class MainPage : Page
       {
          private BluetoothLEDevice device;
          GattDeviceServicesResult serviceResult = null;
          public MainPage()
          {
             this.InitializeComponent();
             StartDevice();
          }
    
          private async void StartDevice()
          {
             //To get your blueToothAddress add: ulong blueToothAddress = device.BluetoothAddress to your old code.
             ulong blueToothAddress = 88396936323791; //fill in your device address!!
             device = await BluetoothLEDevice.FromBluetoothAddressAsync(blueToothAddress);         
             if (device != null)
             {
                string deviceName = device.DeviceInformation.Name;
                Debug.WriteLine(deviceName);
                int servicesCount = 3;//Fill in the amount of services from your device!!
                int tryCount = 0;
                bool connected = false;
                while (!connected)//This is to make sure all services are found.
                {
                   tryCount++;
                   serviceResult = await device.GetGattServicesAsync();
    
                   if (serviceResult.Status == GattCommunicationStatus.Success && serviceResult.Services.Count >= servicesCount)
                   {
                      connected = true;
                      Debug.WriteLine("Connected in " + tryCount + " tries");
                   }
                   if (tryCount > 5)//make this larger if faild
                   {
                      Debug.WriteLine("Failed to connect to device ");
                      return;
                   }
                }
             }
          }
       }
    }
 
