    public static class RestSharpExtensions
    {
        private static readonly Regex structuredSyntaxSuffixRegex = new Regex("\\+\\w+$", RegexOptions.Compiled);
        private static Dictionary<string, IDeserializer> contentTypeToDeserializerMap = new Dictionary
            <string, IDeserializer>
        {
            {"application/json", new JsonDeserializer()},
            {"application/xml", new XmlDeserializer()},
            {"text/json", new JsonDeserializer()},
            {"text/x-json", new JsonDeserializer()},
            {"text/javascript", new JsonDeserializer()},
            {"text/xml", new XmlDeserializer()},
            {"*+json",  new JsonDeserializer()},
            {"*+xml", new XmlDeserializer()},
            {"*",  new XmlDeserializer()}
        };
        public static IDeserializer GetDeserializer(this IRestResponse restResponse)
        {
            var contentType = restResponse.ContentType;
            if (contentType == null)
                throw new ArgumentNullException("contentType");
            if (string.IsNullOrEmpty(contentType) && contentTypeToDeserializerMap.ContainsKey("*"))
                return contentTypeToDeserializerMap["*"];
            int length = contentType.IndexOf(';');
            if (length > -1)
                contentType = contentType.Substring(0, length);
            if (contentTypeToDeserializerMap.ContainsKey(contentType))
                return contentTypeToDeserializerMap[contentType];
            Match match = structuredSyntaxSuffixRegex.Match(contentType);
            if (match.Success)
            {
                string key = "*" + match.Value;
                if (contentTypeToDeserializerMap.ContainsKey(key))
                    return contentTypeToDeserializerMap[key];
            }
            if (contentTypeToDeserializerMap.ContainsKey("*"))
                return contentTypeToDeserializerMap["*"];
            return (IDeserializer)null;
        }
    }
 
