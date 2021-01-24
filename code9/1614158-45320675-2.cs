    public async Task<bool> test()
            {
    
                Debug.WriteLine("Start");
    
                var aqs = SerialDevice.GetDeviceSelector();
                var dis = await DeviceInformation.FindAllAsync(aqs);
                var port = await SerialDevice.FromIdAsync(dis[0].Id);
                Debug.WriteLine("COM=" + port?.PortName);
                //closing device...
                port.Dispose();
                port = null;
    
                var aqs2 = SerialDevice.GetDeviceSelector();
                var dis2 = await DeviceInformation.FindAllAsync(aqs2);
                var port2 = await SerialDevice.FromIdAsync(dis2[0].Id);
                //port2 will be null
                Debug.WriteLine("COM="+port2?.PortName);
    
                Debug.WriteLine("end");
    
                return true;
            }
