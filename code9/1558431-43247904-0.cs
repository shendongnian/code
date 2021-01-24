    public class RowColumnListConverter<T> : JsonConverter
    {
        const string columnsKey = "columns";
        const string rowsKey = "rows";
        public override bool CanConvert(Type objectType)
        {
            if (!typeof(ICollection<T>).IsAssignableFrom(objectType))
                return false;
            // This converter is only implemented for read/write collections.  So no arrays.
            if (objectType.IsArray)
                return false;
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var list = existingValue as ICollection<T> ?? (ICollection<T>)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            var root = JObject.Load(reader);
            var rows = root.GetValue(rowsKey, StringComparison.OrdinalIgnoreCase).NullCast<JArray>();
            if (rows == null)
                return list;
            var columns = root.GetValue(columnsKey, StringComparison.OrdinalIgnoreCase).NullCast<JArray>();
            if (columns == null)
                throw new JsonSerializationException(columnsKey + " not found.");
            var columnNames = columns.Cast<JObject>().SelectMany(o => o.Properties()).Select(p => p.Name).ToArray();
            foreach (var row in rows)
            {
                if (row == null || row.Type == JTokenType.Null)
                    list.Add(default(T));
                else if (row.Type == JTokenType.Array)
                {
                    var o = new JObject(columnNames.Zip(row, (c, r) => new JProperty(c, r)));
                    list.Add(o.ToObject<T>(serializer));
                }
                else
                    throw new JsonSerializationException(string.Format("Row was not an array: {0}", row));
            }
            return list;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class JsonExtensions
    {
        public static TJTOken NullCast<TJTOken>(this JToken token) where TJTOken : JToken
        {
            if (token == null || token.Type == JTokenType.Null)
                return null;
            var typedToken = token as TJTOken;
            if (typedToken == null)
                throw new JsonSerializationException(string.Format("Token {0} was not of type {1}", token.ToString(Formatting.None), typeof(TJTOken)));
            return typedToken;
        }
    }
