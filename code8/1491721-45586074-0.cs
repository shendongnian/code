     DeviceWatcher dWatcher = null;
     var BluetoothDeviceSelector = "System.Devices.DevObjectType:=5 AND System.Devices.Aep.ProtocolId:=\"{BB7BB05E-5972-42B5-94FC-76EAA7084D49}\" AND ((System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#True OR System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#False) OR System.Devices.Aep.Bluetooth.IssueInquiry:=System.StructuredQueryType.Boolean#False)";
     dWatcher = DeviceInformation.CreateWatcher(BluetoothDeviceSelector);
     dWatcher.Added += DeviceAdded;
     dWatcher.Updated += DeviceUpdated;
     dWatcher.Start();
