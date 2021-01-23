    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        [XmlIgnore]
        [JsonProperty]
        public object ExtraData { get; set; }
        [XmlAnyElement("ExtraData")]
        [JsonIgnore]
        public XElement ExtraDataXml
        {
            get
            {
                return JsonExtensions.SerializeExtraDataXElement("ExtraData", ExtraData);
            }
            set
            {
                ExtraData = JsonExtensions.DeserializeExtraDataXElement("ExtraData", value);
            }
        }
    }
    public static class JsonExtensions
    {
        public static XElement SerializeExtraDataXElement(string name, object extraData)
        {
            if (extraData == null)
                return null;
            var token = JToken.FromObject(extraData);
            if (token is JValue)
            {
                return new XElement(name, (string)token);
            }
            else if (token is JArray)
            {
                return new JObject(new JProperty(name, token)).ToXElement(false, name, true);
            }
            else
            {
                return token.ToXElement(false, name, true);
            }
        }
        public static object DeserializeExtraDataXElement(string name, XElement element)
        {
            object extraData;
            if (element == null)
                extraData = null;
            else
            {
                extraData = element.ToJToken(true, name, true);
                if (extraData is JObject)
                {
                    var obj = (JObject)extraData;
                    if (obj.Count == 1 && obj.Properties().First().Name == name)
                        extraData = obj.Properties().First().Value;
                }
                if (extraData is JValue)
                {
                    extraData = ((JValue)extraData).Value;
                }
            }
            return extraData;
        }
        public static XElement ToXElement(this JToken obj, bool omitRootObject, string deserializeRootElementName, bool writeArrayAttribute)
        {
            if (obj == null)
                return null;
            using (var reader = obj.CreateReader())
            {
                var converter = new Newtonsoft.Json.Converters.XmlNodeConverter() { OmitRootObject = omitRootObject, DeserializeRootElementName = deserializeRootElementName, WriteArrayAttribute = writeArrayAttribute };
                var jsonSerializer = JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = { converter } });
                return jsonSerializer.Deserialize<XElement>(reader);
            }
        }
        public static JToken ToJToken(this XElement xElement, bool omitRootObject, string deserializeRootElementName, bool writeArrayAttribute)
        {
            // Convert to Linq to XML JObject
            var settings = new JsonSerializerSettings { Converters = { new XmlNodeConverter { OmitRootObject = omitRootObject, DeserializeRootElementName = deserializeRootElementName, WriteArrayAttribute = writeArrayAttribute } } };
            var root = JToken.FromObject(xElement, JsonSerializer.CreateDefault(settings));
            return root;
        }
    }
