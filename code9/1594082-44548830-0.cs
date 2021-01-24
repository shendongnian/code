    var osDevicesList = (
        from os in context.Device_OperatingSystem
    
        let devicesWithOSCount = (
            from d in context.Device_DeviceDetails
            where d.DOperatingSystemId == os.OperatingSystemID
            select d.Id
        ).Count()
    
        group devicesWithOSCount by os.OSName into g
    
        select new {
            OS = g.Key,
            value = g.First()
        }
    );
