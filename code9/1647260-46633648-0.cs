    Dictionary<Device.enumDevice, Func<string, Device>> _factoryDict =
        new Dictionary<Device.enumDevice, Func<string, Device>>{
            [Device.enumDevice.A34411] = (alias) => new A34411(alias),
            [Device.enumDevice.N5744] = (alias) => new N5744(alias),
        };
    ...
    public static Device GetDevice(Device.enumDevice TypeOfDevice, string alias)
    {
        return _factoryDict[TypeOfDevice](alias);
    }
