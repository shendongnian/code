    public static class JsonExtensions
    {
        const string JsonTypeName = @"$type";
        const string JsonValuesName = @"$values";
        public static void ReformatCollections(Stream inputStream, Stream outputStream, IEnumerable<string> paths, Func<string, string> typeNameMapper, Formatting formatting)
        {
            var root = JToken.Load(new JsonTextReader(new StreamReader(inputStream)) { DateParseHandling = DateParseHandling.None });
            root = ReformatCollections(root, paths, typeNameMapper);
            var writer = new StreamWriter(outputStream);
            var jsonWriter = new JsonTextWriter(writer) { Formatting = formatting };
            root.WriteTo(jsonWriter);
            jsonWriter.Flush();
            writer.Flush();
        }
        public static JToken ReformatCollections(JToken root, IEnumerable<string> paths, Func<string, string> typeNameMapper)
        {
            foreach (var path in paths)
            {
                var token = root.SelectToken(path);
                var newToken = token.ReformatCollection(typeNameMapper);
                if (root == token)
                    root = newToken;
            }
            return root;
        }
        public static JToken ReformatCollection(this JToken value, Func<string, string> typeNameMapper)
        {
            if (value == null || value.Type == JTokenType.Null)
                return value;
            var array = value as JArray;
            if (array == null)
                array = value[JsonValuesName] as JArray;
            if (array == null)
                return value;
            // Extract the item $type and ordered set of properties.
            string type = null;
            var properties = new Dictionary<string, int>();
            foreach (var item in array)
            {
                if (item.Type == JTokenType.Null)
                    continue;
                var obj = item as JObject;
                if (obj == null)
                    throw new JsonSerializationException(string.Format("Item \"{0}\" was not a JObject", obj.ToString(Formatting.None)));
                var objType = (string)obj[JsonTypeName];
                if (objType != null && type == null)
                    type = objType;
                else if (objType != null && type != null)
                {
                    if (type != objType)
                        throw new JsonSerializationException("Too many item types.");
                }
                foreach (var property in obj.Properties().Where(p => p.Name != JsonTypeName))
                {
                    if (!properties.ContainsKey(property.Name))
                        properties.Add(property.Name, properties.Count);
                }
            }
            var propertyList = properties.OrderBy(p => p.Value).Select(p => p.Key).ToArray();
            var newValue = new JObject();
            if (type != null)
                newValue["type"] = JToken.FromObject(typeNameMapper(type));
            newValue["structure"] = JToken.FromObject(propertyList);
            newValue["list"] = JToken.FromObject(array
                .Select(o => (o.Type == JTokenType.Null ? o : propertyList.Where(p => o[p] != null).Select(p => o[p]))));
            if (value.Parent != null)
                value.Replace(newValue);
            return newValue;
        }
    }
