    if (this.mBluetoothAdapter.IsEnabled)
    {
    	BluetoothDevice device = this.mBluetoothAdapter.GetRemoteDevice(Device.Address);
    
    	var serialUUID = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");
    
    	BluetoothSocket socket = device.CreateRfcommSocketToServiceRecord(serialUUID);
    	socket.Connect();
    }
