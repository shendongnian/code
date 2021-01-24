    var deviceA = new GenericDevice
    {
        Name = "Device A",
        CMD_1 = new byte[] { 0x01, 0x02 },
        CMD_2 = new byte[] { 0x03, 0x04 },
        IsReadOnly = true,
    };
    var deviceB = new GenericDevice
    {
        Name = "Device B",
        CMD_1 = Encoding.ASCII.GetBytes("command 1"),
        CMD_2 = Encoding.ASCII.GetBytes("command 2"),
        IsReadOnly = true,
    };
    var devices = new Dictionary<string, GenericDevice>
    {
        { "Device1", deviceA },
        { "Device2", deviceB },
    };
