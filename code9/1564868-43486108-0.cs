    /// <summary>
    /// Default JSON serializer for request bodies
    /// Doesn't currently use the SerializeAs attribute, defers to Newtonsoft's attributes
    /// </summary>
    /// <remarks>
    /// Based on http://blog.patrickmriley.net/2014/02/restsharp-using-jsonnet-serializer.html
    /// </remarks>
    public class RestSharpJsonNetSerializer : RestSharp.Serializers.ISerializer, RestSharp.Deserializers.IDeserializer
    {
        private readonly JsonSerializer serializer;
        /// <summary>
        /// Default serializer
        /// </summary>
        public RestSharpJsonNetSerializer()
        {
            this.ContentType = "application/json";
            this.serializer = new JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }
        /// <summary>
        /// Default serializer with overload for allowing custom Json.NET settings
        /// </summary>
        public RestSharpJsonNetSerializer(JsonSerializer serializer)
        {
            this.ContentType = "application/json";
            this.serializer = serializer;
        }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize></param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';
                    this.serializer.Serialize(jsonTextWriter, obj);
                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }
        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            using (var strReader = new StringReader(response.Content))
            {
                using (var jsonReader = new JsonTextReader(strReader))
                {
                    var data = this.serializer.Deserialize<T>(jsonReader);
                    return data;
                }
            }
        }
    }
