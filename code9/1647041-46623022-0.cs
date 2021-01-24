        public class Device
        {
          public int Id { get; set; }
          public DeviceType DeviceType { get; set; }
          public IList<Device> InConnectedDevices { get; set; }
          public IList<Device> OutConnectedDevices { get; set; }
        }
