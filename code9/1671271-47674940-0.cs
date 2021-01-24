        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
        List<BluetoothDevice> bondedDevices = new List<BluetoothDevice>(bluetoothAdapter.BondedDevices);
        if (bondedDevices.Count > 0)
        {
            foreach (BluetoothDevice device in bondedDevices)
            {
                System.Diagnostics.Debug.Write("Name="+device.Name+" Address="+device.Address);
               
            }
        }
    }
