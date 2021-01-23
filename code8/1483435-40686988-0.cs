    public interface ISerialize<T>
    {
        T Deserialize<T>(string input);
        string Serialize(T type)
    }
    
    public class JsonSerializer<T> : ISerialize<T>
    {
        T Deserialize<T>(string input) {...}
        string Serialize(T type) {...}
    }
    
    public class XmlSerializer<T> : ISerialize<T>
    {
        T Deserialize<T>(string input) {...}
        string Serialize(T type) {...}
    }
