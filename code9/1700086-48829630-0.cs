    public class Building
    {
        //All other properties ...
        
        [JsonIgnore]
        public List<Apartment> Apartments { get; set; }
    }
