    public class SynchronousTelemetryChannel : ITelemetryChannel
    {
        private const string ContentType = "application/x-json-stream";
        private readonly List<ITelemetry> _items;
        private object _lock = new object();
        public bool? DeveloperMode { get; set; }
        public string EndpointAddress { get; set; }
        public SynchronousTelemetryChannel()
        {
            _items = new List<ITelemetry>();
            EndpointAddress = "https://dc.services.visualstudio.com/v2/track";
        }
        public void Send(ITelemetry item)
        {
            lock (_lock)
            {
                _items.Add(item);
            }
        }
        public void Flush()
        {
            lock (_lock)
            {
                try
                {
                    byte[] data = JsonSerializer.Serialize(_items);
                    new Transmission(new Uri(EndpointAddress), data, ContentType, JsonSerializer.CompressionType).SendAsync().Wait();
                    _items.Clear();
                }
                catch (Exception e)
                {
                    // Do whatever you want.
                }
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
