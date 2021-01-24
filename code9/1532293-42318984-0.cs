    public class Airport {
      public string Name { get; set; }
      public string Country { get; set; }
      public string DisplayName {
        get { return Name + ", " + Country; }
      }
    }
