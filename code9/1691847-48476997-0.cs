    public class Country //assuming this is country data
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
        public virtual List<TopLevelDomain> TopLevelDomains { get; set; }
    
        [JsonProperty("callingCodes")]
        public virtual List<CallingCodes> CallingCodes { get; set; }
    
        [JsonProperty("altSpellings")]
        public virtual List<AltSpellings> AltSpellings { get; set; }
    
        [JsonProperty("latlng")]
        public virtual List<Coordinates> Coordinates { get; set; }
    }
    public class TopLevelDomain
    {
        public int Id { get; set; }
        
        [ForeignKey("Country")]
        public int CountryId {get; set; }
        
        public virtual Country Country { get; set; }
        public string DomainName { get; set; }
    }
 
    public class CallingCodes
    {
        public int Id { get; set; }
        
        [ForeignKey("Country")]
        public int CountryId {get; set; }
        
        public virtual Country Country { get; set; }
        public string Code { get; set;} // either store it as String
        //OR
        public long Code { get; set;}
    }
    public class AltSpellings
    {
        public int Id { get; set; }
        
        [ForeignKey("Country")]
        public int CountryId {get; set; }
        
        public virtual Country Country { get; set; }
        public string AltSpelling { get; set; }
    }
    public class Coordinates
    {
        public int Id { get; set; }
        
        [ForeignKey("Country")]
        public int CountryId {get; set; }
        
        public virtual Country Country { get; set; }
        public double Coordinates { get; set; } //again either as string or double, your wish. I would use double
    }
