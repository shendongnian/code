    public class DeviceA : IDevice
    {
        public static readonly DeviceA Instance = new DeviceA();
        private DeviceA()
        {
        }
        public byte[] CMD_1 { get; } = new byte[] { 0x01, 0x02 };
        public byte[] CMD_2 { get; } = new byte[] { 0x03, 0x04 };
    }
    public class DeviceB : IDevice
    {
        public static readonly DeviceB Instance = new DeviceB();
        private DeviceB()
        {
        }
        public byte[] CMD_1 { get; } = Encoding.ASCII.GetBytes("command 1");
        public byte[] CMD_2 { get; } = Encoding.ASCII.GetBytes("command 2");
    }
