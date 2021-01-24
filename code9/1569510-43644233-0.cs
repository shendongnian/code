           BluetoothDeviceInfo selecteddevice = bldialog.SelectedDevice;
                    if (selecteddevice.DeviceName.ToLower().Contains("iphone"))
                         serviceClass = BluetoothService.SerialPort;
                    else if (selecteddevice.DeviceName.ToLower().Contains("allview"))
                         serviceClass = new Guid("00001103-0000-1000-8000-00805f9b34fb");
                    else serviceClass = BluetoothService.ObexFileTransfer;
