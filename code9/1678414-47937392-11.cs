    public class DefaultJsonSerializer<T> : IJsonSerializer<T>
    {
        public T Deserialize(string jsonString)
        {
            return (T)JsonUtility.FromJson<T>(jsonString);
        }
    
        public string Serialize(T jsonObject)
        {
            return JsonUtility.ToJson(jsonObject);
        }
    }
