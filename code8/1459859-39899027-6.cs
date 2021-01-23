    abstract class ADevice<T> where T : ADevice<T>
    {
        public ADevice<T>(T device , string filename)
        {
            // Parsing of the file
            // Plus, setting the Platforms Property
        }
        // Or (but you should keep the first constructor to see the filename dependency)
        public ADevice<T>(T device)
        {
            // Parsing of the file
        }
        public IEnumerable<Platform> Platforms { get; private set; }
        public bool IsCompatibleWith(T device)
        {
            return this.Platforms.Contains(device.Platform); // <- this is type-checking!
        }
    }
