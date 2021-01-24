       public static ExpandoObject ToExpando(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;
            return (ExpandoObject)ToExpandoObject(JToken.Parse(json));
        }
        private static object ToExpandoObject(JToken token)
        {
            
            switch (token.Type)
            {
                case JTokenType.Object:
                    var expando = new ExpandoObject();
                    var expandoDic = (IDictionary<string, object>)expando;
                    foreach(var prop in token.Children<JProperty>())
                        expandoDic.Add(prop.Name, ToExpandoObject(prop.Value));
                    return expando;
                case JTokenType.Array:
                    return token.Select(ToExpandoObject).ToList();
                default:
                    return ((JValue)token).Value;
            }
        }
        var ebj = ToExpando(json);
        var name = (ebj as dynamic).response.events[1].name;
