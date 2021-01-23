    using Newtonsoft.Json;
    public class JSonSerializer : IObjectSerializer
    {
        public string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public T FromJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch(JsonReaderException e)
            {
                throw new ObjectSerializationException(e);
            }
        }
    }
