    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Windows.Devices.Bluetooth;
    using Windows.Devices.Bluetooth.GenericAttributeProfile;
    using Windows.Devices.Enumeration;
    using Windows.UI.Popups;
    using Windows.UI.Xaml.Controls;
    namespace App1
    {
    public sealed partial class MainPage : Page
    {
       GattDeviceServicesResult serviceResult = null;
      private BluetoothLEDevice myDevice;
      private GattCharacteristic selectedCharacteristic;
      public MainPage()
      {
         this.InitializeComponent();
         ConnectDevice();
      }
      private async void ConnectDevice()
      {
         //This works only if your device is already paired!
         foreach (DeviceInformation di in await DeviceInformation.FindAllAsync(BluetoothLEDevice.GetDeviceSelector()))
         {
            BluetoothLEDevice bleDevice = await BluetoothLEDevice.FromIdAsync(di.Id);
            // Display BLE device name
            var dialogBleDeviceName = new MessageDialog("BLE Device Name " + bleDevice.Name);
            await dialogBleDeviceName.ShowAsync();
            myDevice = bleDevice;
         }
         if (myDevice != null)
         {
            int servicesCount = 3;//Fill in the amount of services from your device!!!!!
            int tryCount = 0;
            bool connected = false;
            while (!connected)//This is to make sure all services are found.
            {
               tryCount++;
               serviceResult = await myDevice.GetGattServicesAsync();
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
            if (connected)
            {
               for (int i = 0; i < serviceResult.Services.Count; i++)
               {
                  var service = serviceResult.Services[i];
                  //This must be the service that contains the Gatt-Characteristic you want to read from or write to !!!!!!!.
                  string myServiceUuid = "0000ffe0-0000-1000-8000-00805f9b34fb";
                  if (service.Uuid.ToString() == myServiceUuid)
                  {
                     Get_Characteriisics(service);
                     break;
                  }
               }
            }
         }
      }
      private async void Get_Characteriisics(GattDeviceService myService)
      {
         var CharResult = await myService.GetCharacteristicsAsync();
         if (CharResult.Status == GattCommunicationStatus.Success)
         {
            foreach (GattCharacteristic c in CharResult.Characteristics)
            {
               if (c.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
               {
                  selectedCharacteristic = c;
                  break;
               }
            }
            try
            {
               // Write the ClientCharacteristicConfigurationDescriptor in order for server to send notifications.               
               var result = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                                                         GattClientCharacteristicConfigurationDescriptorValue.Notify);
               if (result == GattCommunicationStatus.Success)
               {
                  var dialogNotifications = new MessageDialog("Successfully registered for notifications");
                  await dialogNotifications.ShowAsync();
                  selectedCharacteristic.ValueChanged += SelectedCharacteristic_ValueChanged;
               }
               else
               {
                  var dialogNotifications = new MessageDialog($"Error registering for notifications: {result}");
                  await dialogNotifications.ShowAsync();
               }
            }
            catch (Exception ex)
            {
               // This usually happens when not all characteristics are found
               // or selected characteristic has no Notify.
               var dialogNotifications = new MessageDialog(ex.Message);
               await dialogNotifications.ShowAsync();
               await Task.Delay(100);
               Get_Characteriisics(myService); //try again
               //!!! Add a max try counter to prevent infinite loop!!!!!!!
            }
         }
         else
         {
            var dialogNotifications = new MessageDialog("Restricted service. Can't read characteristics");
            await dialogNotifications.ShowAsync();
         }
      }
      private void SelectedCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
      {
      }
     }
    }
