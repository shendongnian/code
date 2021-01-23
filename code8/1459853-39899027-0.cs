    abstract class ADevice<T> where T : ADevice<T>
    {
        public ADevice<T>(T device /*, IEnumerable<Platform> platforms ?*/)
        {
        }
        public IEnumerable<Platform> Platforms { get; private set; }
        public bool IsCompatibleWith(T device)
        {
            return this.Platforms.Contains(device.Platform); // <- this is type-checking!
        }
    }
