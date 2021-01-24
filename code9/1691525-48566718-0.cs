    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Reflection;
    public class SensitiveDataJsonConverter : JsonConverter
    {
        private readonly Type[] _types;
        public SensitiveDataJsonConverter(params Type[] types)
        {
          _types = types;
        }
        public override bool CanConvert(Type objectType)
        {
            return _types.Any(e => e == objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
		}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jObject = new JObject();
            var type = value.GetType();
            foreach (var propertyInfo in type.GetProperties())
            {
                // We can only serialize properties with getters
                if (propertyInfo.CanRead)
                {
                    var sensitiveDataAttribute = propertyInfo.GetCustomAttribute<SensitiveDataAttribute>();
                    object propertyValue;
                    if (sensitiveDataAttribute != null)
                        propertyValue = "[REDACTED]";
                    else
                        propertyValue = propertyInfo.GetValue(value);
                    if (propertyValue == null)
                      propertyValue = string.Empty;
                    var jToken = JToken.FromObject(propertyValue, serializer);
                    jObject.Add(propertyInfo.Name, jToken);
                }
            }
            jObject.WriteTo(writer);
        }
