    public interface DriverConfig 
    {
        DriverConfigTemplate driver { get; set; }
        List<DeviceConfig> devices { get; set; }
    }
