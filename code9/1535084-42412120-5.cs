      public class City
        {
            public int CityId { get; set; }
            public string Name { get; set; }
            [ForeignKey("Country")]
            public int CountryId {get;set;}
            public virtual Country Country {get; set;}
        } 
