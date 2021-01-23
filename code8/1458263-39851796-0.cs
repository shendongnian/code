    [MetadataAttribute, AttributeUsage(AttributeTargets.Class)]
    public class TargetDeviceAttribute : Attribute, IDeviceSpecific
    {
        public TargetDeviceAttribute(string deviceId)
        {
            this.DeviceId = deviceId;
        }
        public string DeviceId { get; private set; }
    }
