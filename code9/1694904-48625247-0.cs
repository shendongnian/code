    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string jsonData = @"{
        'Term' : 'john'
       ,'resourceTypes' : ['POL', 'CLM', 'WRK']
       ,'displayInstructions': {'AGB' : {'displayAttributes' : ['AssuredName','PolicyNumber','DistributorName','EffectiveDate'] ,'format':'|resource_type| (|rank|) {0} / {1}'}
                               ,'POL' : {'displayAttributes' : ['AssuredName','PolicyNumber','DistributorName','EffectiveDate'] ,'format':'|resource_type| (|rank|) {0} / {1}'}}
    }";
    
                SearchCriteria des = JsonConvert.DeserializeObject<SearchCriteria>(jsonData);
            }
        }
    
        interface ISearchCriteria
        {
            string Term { get; set; }
            IEnumerable<string> ResourceTypes { get; set; }
            IDisplayInstructions DisplayInstructions { get; set; }
        }
    
        public class ConfigConverter<I, T> : JsonConverter
        {
            public override bool CanWrite => false;
            public override bool CanRead => true;
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(I);
            }
            public override void WriteJson(JsonWriter writer,
                object value, JsonSerializer serializer)
            {
                throw new InvalidOperationException("Use default serialization.");
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var jsonObject = JObject.Load(reader);
                var deserialized = (T)Activator.CreateInstance(typeof(T));
                serializer.Populate(jsonObject.CreateReader(), deserialized);
                return deserialized;
            }
        }
    
        class SearchCriteria : ISearchCriteria
        {
            public string Term { get; set; }
            public IEnumerable<string> ResourceTypes { get; set; }
    
            [JsonConverter(typeof(ConfigConverter<IDisplayInstructions, DisplayInstructions>))]
            public IDisplayInstructions DisplayInstructions { get; set; }
        }
    
        interface IDisplayInstructions : IDictionary<string, IDisplayInstruction> { }
    
        [JsonDictionary(ItemConverterType = typeof(ConfigConverter<IDisplayInstruction, DisplayInstruction>))]
        class DisplayInstructions : Dictionary<string, IDisplayInstruction>, IDisplayInstructions
        {
    
        }
    
        interface IDisplayInstruction
        {
            IEnumerable<string> DisplayAttributes { get; set; }
            string Format { get; set; }
        }
    
        [JsonConverter(typeof(ConfigConverter<IDisplayInstruction, DisplayInstruction>))]
        class DisplayInstruction : IDisplayInstruction
        {
            public IEnumerable<string> DisplayAttributes { get; set; }
            public string Format { get; set; }
        }
    }
  
