    public partial class GettingStarted
        {
            public static GettingStarted[] FromJson(string json) => JsonConvert.DeserializeObject<GettingStarted[]>(json, Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this GettingStarted[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }
    
        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
