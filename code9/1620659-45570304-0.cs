    public class Plane
    {
      // included in JSON
      public string Model { get; set; }
      public DateTime Year { get; set; }
    
      // ignored
      [JsonIgnore]
      public DateTime LastModified { get; set; }
    }
