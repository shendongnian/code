    Android.Bluetooth.BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
	if (bluetoothAdapter.IsEnabled)
	{
		bluetoothAdapter.Disable();
	}
	else
	{
		bluetoothAdapter.Enable();
	}
