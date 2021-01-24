    private static Dictionary<Device.enumDevice, Func<string, Device>> _factoryDict =
        new Dictionary<Device.enumDevice, Func<string, Device>>{
            [Device.enumDevice.A34411] = (alias) => new A34411(alias),
            [Device.enumDevice.N5744] = (alias) => new N5744(alias),
        };
    ...
    public static Device GetDevice(Device.enumDevice TypeOfDevice, string alias)
    {
        if (_factoryDict.TryGetValue(TypeOfDevice, out var factory)) {
            return factory(alias);
        }
        throw new NotImplementedException();
        // No retun statement here, as it would be unreachable because of the throw statement.
    }
