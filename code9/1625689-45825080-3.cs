    public static class JsonExtensions
    {
        const string JsonNamespace = @"http://james.newtonking.com/projects/json";
        const string ArrayAttributeName = @"Array";
        public static JToken ToJToken(this XElement xElement, bool omitRootObject, string deserializeRootElementName)
        {
            return xElement.ToJToken(omitRootObject, deserializeRootElementName, Enumerable.Empty<Func<XElement, IEnumerable<XElement>>>());
        }
        public static JToken ToJToken(this XElement xElement, bool omitRootObject, string deserializeRootElementName, IEnumerable<Func<XElement, IEnumerable<XElement>>> arrayQueries)
        {
            foreach (var query in arrayQueries)
            {
                var name = XName.Get(ArrayAttributeName, JsonNamespace);
                foreach (var element in query(xElement))
                {
                    element.SetAttributeValue(name, true);
                }
            }
            // Convert to Linq to XML JObject
            var settings = new JsonSerializerSettings { Converters = { new XmlNodeConverter { OmitRootObject = omitRootObject, DeserializeRootElementName = deserializeRootElementName } } };
            var root = JToken.FromObject(xElement, JsonSerializer.CreateDefault(settings));
            return root;
        }
    }
