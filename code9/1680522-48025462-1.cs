    [JsonConverter(typeof(SpecificConverter))]
    [DataContract]
    public class Specific<T>
    {
        public Specific(T obj)
        {
            Object = obj;
        }
        public string Common { get; set; } = "common";
        public T Object { get; set; }
    }
    ...
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        dynamic dyn = value;
        JToken t = JToken.FromObject(dyn.Object);
        t.First.AddBeforeSelf(new JProperty("Common", dyn.Common));
        t.WriteTo(writer);
    }
    ...
    public override bool CanConvert(Type objectType)
    {
        return typeof(Specific<>).IsAssignableFrom(objectType);
    }
    ...
    public static class SepcificHelper
    {
        public static Specific<T> ToSpecific<T>(T obj)
        {
            return new Specific<T>(obj);
        }
    }
