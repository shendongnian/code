        public class Base
        {
            public string PropBase { get; set; }
        }
    
        public class Derived : Base
        {
            public string PropDerived { get; set; }
        }
    
        [JsonConverter(typeof(SpecificConverter))]
        [DataContract]
        public class Specific
        {
            public Specific(object obj)
            {
                Object = obj;
            }
            public bool Common { get; set; }
    
            public object Object { get; set; }
        }
    
        public class SpecificConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                Specific obj = value as Specific;
                JToken t = JToken.FromObject(obj.Object);
                t.First.AddBeforeSelf(new JProperty("Common", obj.Common));
                t.WriteTo(writer);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
            }
    
            public override bool CanRead
            {
                get { return false; }
            }
    
            public override bool CanConvert(Type objectType)
            {
                return typeof(Specific).IsAssignableFrom(objectType);
            }
        }
    }
