    const string deviceNameSpace = "MyName.MyProject.Devices.";
    public static Device GetDevice(Device.enumDevice deviceType, string alias)
    {
        string typeName = deviceNameSpace + deviceType.ToString();
        Type type = Type.GetType(typeName, throwOnError: true);
        return (Device)Activator.CreateInstance(type, alias);
    }
