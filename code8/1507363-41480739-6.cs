    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetListType() == typeof(T);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var list = (IList)(existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
            if (reader.TokenType == JsonToken.StartArray)
            {
                serializer.Populate(reader, list);
            }
            else
            {
                list.Add(serializer.Deserialize(reader, objectType.GetListType()));
            }
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (IList)value;
            if (list.Count == 1)
                serializer.Serialize(writer, list[0]);
            else
            {
                writer.WriteStartArray();
                foreach (var item in list)
                    serializer.Serialize(writer, item);
                writer.WriteEndArray();
            }
        }
    }
    public static class TypeExtensions
    {
        public static Type GetListType(this Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();
                    if (genType == typeof(List<>))
                        return type.GetGenericArguments()[0];
                }
                type = type.BaseType;
            }
            return null;
        }
    }
    public class StringConverterDecorator : JsonConverterDecorator
    {
        public StringConverterDecorator(Type jsonConverterType) : base(jsonConverterType) { }
        public StringConverterDecorator(JsonConverter converter) : base(converter) { }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            // Unwrap the double-serialized string.
            var s = JToken.Load(reader).ToString();
            var token = JToken.Parse(s);
            // Then convert the revealed JSON to its final form.
            using (var subReader = token.CreateReader())
            {
                while (subReader.TokenType == JsonToken.None)
                    subReader.Read();
                return base.ReadJson(subReader, objectType, existingValue, serializer);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string s;
            // Serialize the value to an intermediate JSON string.
            using (var textWriter = new StringWriter())
            {
                using (var subWriter = new JsonTextWriter(textWriter))
                {
                    base.WriteJson(subWriter, value, serializer);
                }
                s = textWriter.ToString();
            }
            // Then double-serialize the value by writing the JSON as a string literal to the output stream.
            writer.WriteValue(s);
        }
    }
    public abstract class JsonConverterDecorator : JsonConverter
    {
        readonly JsonConverter converter;
        public JsonConverterDecorator(Type jsonConverterType) : this((JsonConverter)Activator.CreateInstance(jsonConverterType)) { }
        public JsonConverterDecorator(JsonConverter converter)
        {
            if (converter == null)
                throw new ArgumentNullException();
            this.converter = converter;
        }
        public override bool CanConvert(Type objectType)
        {
            return converter.CanConvert(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return converter.ReadJson(reader, objectType, existingValue, serializer);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            converter.WriteJson(writer, value, serializer);
        }
        public override bool CanRead { get { return converter.CanRead; } }
        public override bool CanWrite { get { return converter.CanWrite; } }
    }
