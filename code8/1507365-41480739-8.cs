    public class SingleOrArrayConverter<TCollection, TItem> : SingleOrArrayConverter where TCollection : ICollection<TItem>
    {
        public override bool CanConvert(Type objectType)
        {
            if (!base.CanConvert(objectType))
                return false;
            return typeof(TCollection).IsAssignableFrom(objectType);
        }
    }
    public class SingleOrArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsArray || objectType == typeof(string) || objectType.IsPrimitive)
                return false;
            Type elementType = null;
            foreach (var type in objectType.GetCollectItemTypes())
            {
                if (elementType == null)
                    elementType = type;
                else
                    return false;
            }
            return elementType != null;
        }
        object ReadJsonGeneric<TItem>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var collection = (ICollection<TItem>)(existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
            if (reader.TokenType == JsonToken.StartArray)
                serializer.Populate(reader, collection);
            else
                collection.Add(serializer.Deserialize<TItem>(reader));
            return collection;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (objectType.IsArray)
                throw new JsonSerializationException("Read-only collections such as arrays are not supported");
            try
            {
                var elementType = objectType.GetCollectItemTypes().SingleOrDefault();
                if (elementType == null)
                    throw new JsonSerializationException(string.Format("{0} is not an ICollection<T> for some T", objectType));
                var method = typeof(SingleOrArrayConverter).GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                return method.MakeGenericMethod(new[] { elementType }).Invoke(this, new object[] { reader, objectType, existingValue, serializer });
            }
            catch (Exception ex)
            {
                // Wrap the TargetInvocationException in a JsonSerializerException
                throw new JsonSerializationException("Failed to deserialize " + objectType, ex);
            }
        }
        void WriteJsonGeneric<TItem>(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (ICollection<TItem>)value;
            if (list.Count == 1)
            {
                foreach (object item in list)
                {
                    serializer.Serialize(writer, item);
                    break;
                }
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in list)
                {
                    serializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            try
            {
                var elementType = objectType.GetCollectItemTypes().SingleOrDefault();
                if (elementType == null)
                    throw new JsonSerializationException(string.Format("{0} is not an ICollection<T> for some T", objectType));
                var method = typeof(SingleOrArrayConverter).GetMethod("WriteJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                method.MakeGenericMethod(new[] { elementType }).Invoke(this, new object[] { writer, value, serializer });
            }
            catch (Exception ex)
            {
                // Wrap the TargetInvocationException in a JsonSerializerException
                throw new JsonSerializationException("Failed to serialize " + objectType, ex);
            }
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }
        public static IEnumerable<Type> GetCollectItemTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    yield return intType.GetGenericArguments()[0];
                }
            }
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
