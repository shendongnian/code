    List<DeviceType> deviceTypeList = new List<DeviceType>() { 
                new DeviceType { id = 1, Name = "Device Type 1" }, 
                new DeviceType { id = 2, Name = "Device Type 2" } };
    List<Device> deviceList = new List<Device>() { 
                new Device { id = 1, Name = "Device1", DeviceTypeId = 1 },
                new Device { id = 2, Name = "Device2", DeviceTypeId = 1 },
                new Device { id = 3, Name = "Device3", DeviceTypeId = 2 } };
    //Linq
    var query = from device in deviceList
            join type in deviceTypeList
            on device.DeviceTypeId equals type.id
            select new { Id = device.id, Name = device.Name,
            DeviceTypeName = type.Name };
 
    //Or lambda expressions
    var query = deviceList.Join(deviceTypeList,
            device => device.DeviceTypeId,
            type => type.id,
            (device, type) => new { Id = device.id, Name = device.Name, 
            DeviceTypeName = type.Name });
