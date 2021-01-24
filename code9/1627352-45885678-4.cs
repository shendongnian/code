    public static class SqlPrimitiveConverters
    {
        public static JsonSerializerSettings AddSqlConverters(this JsonSerializerSettings settings)
        {
            foreach (var converter in converters)
                settings.Converters.Add(converter);
            return settings;
        }
        static readonly JsonConverter[] converters = new JsonConverter[]
        {
            new SqlBinaryConverter(),
            new SqlBooleanConverter(),
            new SqlByteConverter(),
            new SqlDateTimeConverter(),
            new SqlDecimalConverter(),
            new SqlDoubleConverter(),
            new SqlGuidConverter(),
            new SqlInt16Converter(),
            new SqlInt32Converter(),
            new SqlInt64Converter(),
            new SqlMoneyConverter(),
            new SqlSingleConverter(),
            new SqlStringConverter(),
            // TODO: converters for primitives from System.Data.SqlTypes that are classes not structs:
            // SqlBytes, SqlChars, SqlXml
            // Maybe SqlFileStream
        };
    }
    abstract class SqlPrimitiveConverterBase<T> : JsonConverter where T : struct, INullable, IComparable
    {
        protected abstract object GetValue(T sqlValue);
        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            T sqlValue = (T)value;
            if (sqlValue.IsNull)
                writer.WriteNull();
            else
            {
                serializer.Serialize(writer, GetValue(sqlValue));
            }
        }
    }
    class SqlBinaryConverter : SqlPrimitiveConverterBase<SqlBinary>
    {
        protected override object GetValue(SqlBinary sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlBinary.Null;
            return (SqlBinary)serializer.Deserialize<byte[]>(reader);
        }
    }
    class SqlBooleanConverter : SqlPrimitiveConverterBase<SqlBoolean>
    {
        protected override object GetValue(SqlBoolean sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlBoolean.Null;
            return (SqlBoolean)serializer.Deserialize<bool>(reader);
        }
    }
    class SqlByteConverter : SqlPrimitiveConverterBase<SqlByte>
    {
        protected override object GetValue(SqlByte sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlByte.Null;
            return (SqlByte)serializer.Deserialize<byte>(reader);
        }
    }
    class SqlDateTimeConverter : SqlPrimitiveConverterBase<SqlDateTime>
    {
        protected override object GetValue(SqlDateTime sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlDateTime.Null;
            return (SqlDateTime)serializer.Deserialize<DateTime>(reader);
        }
    }
    class SqlDecimalConverter : SqlPrimitiveConverterBase<SqlDecimal>
    {
        protected override object GetValue(SqlDecimal sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlDecimal.Null;
            return (SqlDecimal)serializer.Deserialize<decimal>(reader);
        }
    }
    class SqlDoubleConverter : SqlPrimitiveConverterBase<SqlDouble>
    {
        protected override object GetValue(SqlDouble sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlDouble.Null;
            return (SqlDouble)serializer.Deserialize<double>(reader);
        }
    }
    class SqlGuidConverter : SqlPrimitiveConverterBase<SqlGuid>
    {
        protected override object GetValue(SqlGuid sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlGuid.Null;
            return (SqlGuid)serializer.Deserialize<Guid>(reader);
        }
    }
    class SqlInt16Converter : SqlPrimitiveConverterBase<SqlInt16>
    {
        protected override object GetValue(SqlInt16 sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlInt16.Null;
            return (SqlInt16)serializer.Deserialize<short>(reader);
        }
    }
    class SqlInt32Converter : SqlPrimitiveConverterBase<SqlInt32>
    {
        protected override object GetValue(SqlInt32 sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlInt32.Null;
            return (SqlInt32)serializer.Deserialize<int>(reader);
        }
    }
    class SqlInt64Converter : SqlPrimitiveConverterBase<SqlInt64>
    {
        protected override object GetValue(SqlInt64 sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlInt64.Null;
            return (SqlInt64)serializer.Deserialize<long>(reader);
        }
    }
    class SqlMoneyConverter : SqlPrimitiveConverterBase<SqlMoney>
    {
        protected override object GetValue(SqlMoney sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlMoney.Null;
            return (SqlMoney)serializer.Deserialize<decimal>(reader);
        }
    }
    class SqlSingleConverter : SqlPrimitiveConverterBase<SqlSingle>
    {
        protected override object GetValue(SqlSingle sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlSingle.Null;
            return (SqlSingle)serializer.Deserialize<float>(reader);
        }
    }
    class SqlStringConverter : SqlPrimitiveConverterBase<SqlString>
    {
        protected override object GetValue(SqlString sqlValue) { return sqlValue.Value; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return SqlString.Null;
            return (SqlString)serializer.Deserialize<string>(reader);
        }
    }
