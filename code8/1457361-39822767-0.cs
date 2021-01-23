    public class DataConverter : JsonConverter
    {
        #region Overriding
        public override bool CanRead
        {
            get { return true; }
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return this.ReadValue(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            this.WriteValue(writer, value, serializer);
        }
        #endregion
        #region Assistants
        private object ReadValue(JsonReader reader)
        {
            while (reader.TokenType == JsonToken.Comment)
            {
                if (reader.Read() == false)
                    throw new Exception("Unexpected end.");
            }
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    return this.ReadObject(reader);
                case JsonToken.StartArray:
                    return this.ReadList(reader);
                default:
                    if (this.CheckPrimitive(reader.TokenType) == true)
                        return reader.Value;
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected token when converting ExpandoObject: {0}", reader.TokenType));
            }
        }
        private object ReadList(JsonReader reader)
        {
            List<object> collection = new List<object>();
            while (reader.Read() == true)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndArray:
                        return collection;
                    default:
                        object value = this.ReadValue(reader);
                        collection.Add(value);
                        break;
                }
            }
            throw new Exception("Unexpected end.");
        }
        private object ReadObject(JsonReader reader)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            while (reader.Read() == true)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        string property = reader.Value.ToString().ToCase(Casing.Pascal);
                        if (reader.Read() == false)
                            throw new Exception("Unexpected end.");
                        object value = this.ReadValue(reader);
                        expando[property] = value;
                        break;
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndObject:
                        return expando;
                }
            }
            throw new Exception("Unexpected end.");
        }
        private void WriteValue(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (this.CheckPrimitive(value) == true)
            {
                writer.WriteValue(value);
                return;
            }
            if (value is Guid)
            {
                this.WriteValue(writer, (Guid)value, serializer);
                return;
            }
            if (value is MyType)
            {
                this.WriteValue(writer, (MyType)value, serializer);
                return;
            }
            if (value is IDynamicMetaObjectProvider && value is IDictionary<string, object>)
            {
                this.WriteObject(writer, (IDictionary<string, object>)value, serializer);
                return;
            }
            if (value is IEnumerable)
            {
                IEnumerable enumerable = value as IEnumerable;
                this.WriteArray(writer, enumerable, serializer);
                return;
            }
            this.WriteObject(writer, value, serializer);
        }
        private void WriteValue(JsonWriter writer, Guid guid, JsonSerializer serializer)
        {
            writer.WriteValue(guid.ToString());
        }
        private void WriteValue(JsonWriter writer, MyType myType, JsonSerializer serializer)
        {
            writer.WriteValue(myType.ToString());
        }
        private void WriteArray(JsonWriter writer, IEnumerable enumerable, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (object value in enumerable)
            {
                this.WriteValue(writer, value, serializer);
            }
            writer.WriteEndArray();
        }
        private void WriteObject(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (PropertyInfo properties in value.GetType().GetProperties())
            {
                ParameterInfo[] parameters = properties.GetGetMethod().GetParameters();
                if (parameters.Length == 0)
                {
                    writer.WritePropertyName(properties.Name.ToCase(Casing.Camel));
                    this.WriteValue(writer, properties.GetValue(value), serializer);
                }
            }
            writer.WriteEndObject();
        }
        private void WriteObject(JsonWriter writer, IDictionary<string, object> value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (KeyValuePair<string, object> properties in value)
            {
                writer.WritePropertyName(properties.Key.ToCase(Casing.Camel)); // Implement own casing...
                this.WriteValue(writer, properties.Value, serializer);
            }
            writer.WriteEndObject();
        }
        private bool CheckPrimitive(JsonToken token)
        {
            switch (token)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.Null:
                case JsonToken.Undefined:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return true;
            }
            return false;
        }
        private bool CheckPrimitive(object value)
        {
            if (value == null)
                return true;
            if (value is bool)
                return true;
            if (value is byte)
                return true;
            if (value is sbyte)
                return true;
            if (value is short)
                return true;
            if (value is ushort)
                return true;
            if (value is int)
                return true;
            if (value is uint)
                return true;
            if (value is long)
                return true;
            if (value is ulong)
                return true;
            if (value is float)
                return true;
            if (value is double)
                return true;
            if (value is decimal)
                return true;
            if (value is char)
                return true;
            if (value is string)
                return true;
            if (value is DateTime)
                return true;
            if (value is Enum)
                return true;
            return false;
        }
        #endregion
    }
