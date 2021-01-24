    class Place {
          public string Name { get; set; }
          public CountryItem Country { get; set; }
          //other properties...
          public object ToPlaceJson() {
                return new { name = Name, country = Country };
          }
    }
