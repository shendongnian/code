    public interface IRegistryActions
    {
         bool WriteValue(string key, string value);
    }
    public class RegistryActions : IRegistryActions
    {
        public bool WriteValue(string key, string value)
        {
            // pseudocode
            // var key = Registry.OpenKey(key);
            // Registry.WriteValue(key, value);
        }
    }
