    class Program {
        static void Main(string[] args) {
            // throws
            ConfigurationManager.GetSection("store");                        
        }
    }
    public class StoreElement : ConfigurationSection
    {
        [ConfigurationProperty("storageProvider")]
        public StorageProviderElement StorageProvider { get; }
    }
    public class StorageProviderElement : ConfigurationElement {
        [ConfigurationProperty("whatever")]
        public StorageProviderElement Whatever { get; }
    }
