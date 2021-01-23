    public class SerialDriverConfig<T> : DriverConfig<T>
    {
        public DriverConfigTemplate driver { get; set; }
        public List<T> devices { get; set; }
    }
