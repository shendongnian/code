    //Model the JSON Web Key Set
    public class JsonWebKeySet
    {
         [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "keys", Required = Required.Default)]
         public JsonWebKey[] Keys { get; set; }
    }
    //Model the JSON Web Key object
    public class JsonWebKey
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "kty", Required = Required.Default)]
        public string Kty { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "use", Required = Required.Default)]
        public string Use { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "kid", Required = Required.Default)]
        public string Kid { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5t", Required = Required.Default)]
        public string X5T { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "e", Required = Required.Default)]
        public string E { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "n", Required = Required.Default)]
        public string N { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5c", Required = Required.Default)]
        public string[] X5C { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "alg", Required = Required.Default)]
        public string Alg { get; set; }
    }
