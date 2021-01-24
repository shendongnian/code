    public interface IJsonSerializer<T>
    {
        T Deserialize(string jsonString);
        string Serialize(T jsonObject);
    }
