    public class CountryJson 
    {
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("alpha2Code")]
        public string Alpha2Code { get; set; }
    
        [JsonProperty("alpha3Code")]
        public string Alpha3Code { get; set; }
    
        [JsonProperty("capital")]
        public string Capital { get; set; }
    
        [JsonProperty("region")]
        public string Region { get; set; }
    
        [JsonProperty("subregion")]
        public string Subregion { get; set; }
    
        [JsonProperty("population")]
        public long Population { get; set; }
    
        [JsonProperty("topLevelDomain")]
        public List<string> TopLevelDomains { get; set; }
        
        [JsonProperty("callingCodes")]
        public List<string> CallingCodes { get; set;}
        
        [JsonProperty("altSpellings")]
        public List<string> AltSpellings { get; set; }
        [JsonProperty("latlng")]
        public List<string> Latlng { get; set; }
    }
