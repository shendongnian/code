    public static class JsonHelper
    {
        public static string Serialize(this object value)
        {
            return value != null 
                ? JsonConvert.SerializeObject(value) 
                : String.Empty;
        }
        public static T Deserialize<T>(this string json)
            where T : class, new()
        {
            return !String.IsNullOrWhiteSpace(json) 
                ? JsonConvert.DeserializeObject<T>(json)
                : null;
        }
    }
