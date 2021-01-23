    public enum ObjectType
    {
        container,
        banner
    }
    public class MyObject
    {
        public int width;
        public int height;
        [JsonConverter(typeof(StringEnumConverter))]
        public ObjectType objectType;
    }
