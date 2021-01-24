    public static Device GetDevice(Device.enumDevice deviceType, string alias)
    {
        string typeName = deviceType.ToString();
        Type type = Type.GetType(typeName, throwOnError: true);
        return (Device)Activator.CreateInstance(type, alias);
    }
