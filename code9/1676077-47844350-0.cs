        [DataContract]
        public class MyModel
        {
            [DataMember(Name = "Country of Origin")]
            public string CountryOfOrigin { get; set; }
        
            [DataMember(Name = "Commodity")]
            public string Commodity { get; set; }
        
            // other fields
        }
    
    Also, note I used DataContract and DataMember attributes as incoming
    JSON fields not normalized (fields has spaces and different case
    (camelCase and CamelCaps)).
    If you will normalize your JSON to camelCase, you may remove DataContract and DataMember attributes.
