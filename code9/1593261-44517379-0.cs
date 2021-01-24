    public class User
    {
        public User(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jRaw = jObject["raw"];
            Token = (string) jRaw["token"];
            queryName = (string) jRaw["queryName"];
            dataTestToSEND = (List<string>) jRaw["dataTestToSEND"];
            Region= jRaw["players"].ToArray();
        }
    
        public string Token {get;set;}
        public string queryName {get;set;}
        public List<string> dataTestToSEND {get;set}
        public string Region{get;set}
    }
    // Call User with your json
    string json = @"{""body"":{""mode"":""raw"",""raw"":{""Token"":""123123"",""queryName"":""testMethod"",""dataTestToSEND"":{""IDs"":[""B00448MZUW"",""B071F7LBN6"",""B01BBZJZHQ""],""Marketplace"":""southAmerica"",""Region"":""West"",""PricingMethod"":""0""}}},""description"":""somedescriptionhere""}";
    User user = new User(json);
