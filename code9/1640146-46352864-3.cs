        private static Type GetColumnDataType(JsonReader reader, string columnName)
        {
            JsonToken tokenType = reader.TokenType;
            switch (tokenType)
            {
                case JsonToken.String:
                    if (columnName.IndexOf("date", StringComparison.OrdinalIgnoreCase) >= 0)
                        return typeof(DateTime);
                    return reader.ValueType;
                case JsonToken.Integer:
                case JsonToken.Boolean:
                case JsonToken.Float:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return reader.ValueType;
                case JsonToken.Null:
                case JsonToken.Undefined:
                    if (columnName.IndexOf("date", StringComparison.OrdinalIgnoreCase) >= 0)
                        return typeof(DateTime);
                    return typeof(string);
                case JsonToken.StartArray:
                    reader.ReadAndAssert();
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        return typeof(DataTable); // nested datatable
                    }
                    Type arrayType = GetColumnDataType(reader, columnName);
                    return arrayType.MakeArrayType();
                default:
                    throw JsonSerializationException.Create(reader, "Unexpected JSON token when reading DataTable: {0}".FormatWith(CultureInfo.InvariantCulture, tokenType));
            }
        }
