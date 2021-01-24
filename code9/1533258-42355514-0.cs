    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    
    namespace JsonNamedList
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Destinations object
                var destinations = MockGetDestinations();
                //Destinations object as Json string, use the LongNameContractResolver to ignore the Json Property Name
                var strDestinationsJson = LongNameContractResolver.Serialize(destinations, true);
                //Print the destinations Json to output
                Console.WriteLine(strDestinationsJson);
                //Stop closing the console window
                Console.ReadKey();
            }
    
            static Destinations MockGetDestinations()
            {
                //[{"Name":"reject","status":"FULL"},{"Name":"returns","status":"OK"}]
                var apiResponse = "[{'Name':'reject','status':'FULL'},{ 'Name':'returns','status':'OK'}]".Replace("'", "\"");
                var wrappedApiResponse = WrapIntoDestinations(apiResponse);
                //destinations as object
                var destinations = JsonConvert.DeserializeObject<Destinations>(wrappedApiResponse);
    
                return destinations;
            }
    
            static string WrapIntoDestinations(string apiResponse) => $"{{'destinations': {apiResponse} }}".Replace("'", "\"");
        }
    
        public class Destination
        {
            [JsonProperty(PropertyName = "Name")]
            public string destinationName { get; set; }
    
            [JsonProperty(PropertyName = "status")]
            public string status { get; set; }
        }
        public class Destinations
        {
            [JsonProperty(PropertyName = "destinations")]
            public IEnumerable<Destination> destinations { get; set; }
        }
        public class LongNameContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                // Let the base class create all the JsonProperties 
                // using the short names
                IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
    
                // Now inspect each property and replace the 
                // short name with the real property name
                foreach (JsonProperty prop in list)
                {
                    prop.PropertyName = prop.UnderlyingName;
                }
    
                return list;
            }
            public static string Serialize(object obj, bool useLongNames)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.Indented;
                if (useLongNames)
                {
                    settings.ContractResolver = new LongNameContractResolver();
                }
    
                return JsonConvert.SerializeObject(obj, settings);
            }
        }
    }
