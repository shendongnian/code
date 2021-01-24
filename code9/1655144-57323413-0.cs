    public static Function Model { get; set; }
    public Function Load(string modelFilePath, DeviceDescriptor device)
    {
        return Function.Load(modelFilePath, device);
    }
