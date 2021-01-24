    namespace WhitePagesTool
    {
        class JsonPersonComplex
        {
            public string Id { get; set; }
            public string Phone_number { get; set; }
            public bool Is_valid { get; set; }
            public string Line_type { get; set; }
            public string Carrier { get; set; }
            public bool Is_prepaid { get; set; }
            public bool Is_commercial { get; set; }
            public List<BelongsTo> Belongs_to { get; set; }
            
            //Current_addresses added to address comments below.
            public List<CurrentAddress> Current_addresses { get; set; }
        }
    
        public class BelongsTo
        {
            public string Name { get; set; }
            public string Firstname { get; set; }
            public string Middlename { get; set; }
            public string Lastname { get; set; }
            public string Age_range { get; set; }
            public string Gender { get; set; }
            public string Type { get; set; }
    
        }
    
        public class CurrentAddress
        {
            public string Street_line_1 { get; set; }
            public object Street_line_2 { get; set; }
            public string City { get; set; }
            public string Postal_code { get; set; }
            public string State_code { get; set; }
            public string Country_code { get; set; }
            public LatLong Lat_long { get; set; }
        }
    
        public class LatLong
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Accuracy { get; set; }
        }
    
        public class AssociatedPeople
        {
            public string Name { get; set; }
            public string Firstname { get; set; }
            public string Middlename { get; set; }
            public string Lastname { get; set; }
            public string Relation { get; set; }
        }
    }
