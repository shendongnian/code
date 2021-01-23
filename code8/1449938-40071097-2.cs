    public class Devices_ByStringValue : AbstractIndexCreationTask<Device>
    {
        public override string IndexName => "Devices/ByStringValue";
        public Devices_ByStringValue()
        {
            Map = devices => from device in devices
                              select new { device.MyStringValues };
        }
    }
