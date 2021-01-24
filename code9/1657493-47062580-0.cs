    namespace QuickType
    {
        using System;
        using System.Net;
        using System.Collections.Generic;
    
        using Newtonsoft.Json;
    
        public partial class GettingStarted
        {
            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }
    
            [JsonProperty("results")]
            public Result[] Results { get; set; }
        }
    
        public partial class Result
        {
            [JsonProperty("id")]
            public string Id { get; set; }
    
            [JsonProperty("language")]
            public string Language { get; set; }
    
            [JsonProperty("lexicalEntries")]
            public LexicalEntry[] LexicalEntries { get; set; }
    
            [JsonProperty("type")]
            public string Type { get; set; }
    
            [JsonProperty("word")]
            public string Word { get; set; }
        }
    
        public partial class LexicalEntry
        {
            [JsonProperty("entries")]
            public Entry[] Entries { get; set; }
    
            [JsonProperty("language")]
            public string Language { get; set; }
    
            [JsonProperty("lexicalCategory")]
            public string LexicalCategory { get; set; }
    
            [JsonProperty("text")]
            public string Text { get; set; }
        }
    
        public partial class Entry
        {
            [JsonProperty("homographNumber")]
            public string HomographNumber { get; set; }
    
            [JsonProperty("senses")]
            public Sense[] Senses { get; set; }
        }
    
        public partial class Sense
        {
            [JsonProperty("definitions")]
            public string[] Definitions { get; set; }
    
            [JsonProperty("id")]
            public string Id { get; set; }
    
            [JsonProperty("subsenses")]
            public Subsense[] Subsenses { get; set; }
        }
    
        public partial class Subsense
        {
            [JsonProperty("definitions")]
            public string[] Definitions { get; set; }
    
            [JsonProperty("id")]
            public string Id { get; set; }
        }
    
        public partial class Metadata
        {
            [JsonProperty("provider")]
            public string Provider { get; set; }
        }
    
        public partial class GettingStarted
        {
            public static GettingStarted FromJson(string json) => JsonConvert.DeserializeObject<GettingStarted>(json, Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this GettingStarted self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
