    namespace QuickType
    {
        using System;
        using System.Net;
        using System.Collections.Generic;
    
        using Newtonsoft.Json;
    
        public partial class Quote
        {
            [JsonProperty("asks")]
            public List<List<double>> Asks { get; set; }
    
            [JsonProperty("bids")]
            public List<List<double>> Bids { get; set; }
        }
    
        public partial class Quote
        {
            public static Quote FromJson(string json) =>
                JsonConvert.DeserializeObject<Quote>(json, Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Quote self) =>
                JsonConvert.SerializeObject(self, Converter.Settings);
        }
    
        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }
