    public class JSON
    {
        public static string ConvertEntityToJSON(object dataToSerialize)
        {
            return JsonConvert.SerializeObject(dataToSerialize,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new UnderscorePropertyNamesContractResolver()
                });
        }
    }
    public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
    {
        public UnderscorePropertyNamesContractResolver() : base()
        {
        }
        protected override string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, "_", " ");
        }
    }
