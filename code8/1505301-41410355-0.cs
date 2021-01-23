    public static Device GetFreeDevice()
        {
             List<Device> OnlineDevices = new List<Device>()
            {
                new Device { IP="192.168.1.15",Name="PerryLabtop",MAC="AC:DS:F2:CC:2D:7A"},
                new Device { IP="192.168.1.20",Name="MAYA-PC",MAC="7D:E9:2C:FF:E7:2D"},
                new Device { IP="192.168.1.2",Name="server",MAC="D8:C2:A4:DC:E5:3A"}
            };
            Device FreeDevice = OnlineDevices.Where(x => !UsedDevices.Contains(x)).SingleOrDefault();
            if (FreeDevice != null)
                lock (UsedDevices)
                    UsedDevices.Add(FreeDevice);
            return FreeDevice;
        }
