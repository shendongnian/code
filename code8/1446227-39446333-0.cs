    public class DeviceModelBase
    {
        public int DevicesID { get; set; }
        public string DeviceUID { get; set; }
        public string MACAddress { get; set; }
    }
    public class DeviceModel : DeviceModelBase
    {        
        public bool Allowed { get; set; }
        public UserModel Owner { get; set; }
    }
