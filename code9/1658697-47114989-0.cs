        public static object ToObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;
            return ToObject(JToken.Parse(json));
        }
        private static object ToObject(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    return token.Children<JProperty>()
                                .ToDictionary(prop => prop.Name,
                                              prop => ToObject(prop.Value),
                                              StringComparer.OrdinalIgnoreCase);
                case JTokenType.Array:
                    return token.Select(ToObject).ToList();
                default:
                    return ((JValue)token).Value;
            }
        }
