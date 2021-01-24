    public class LinkElement
    {
      public string Link { get; set; }
      public string Description { get; set; }
      public string Type { get; set; }
      public string[] Tags { get; set; }
    }
    private Dictionary<string, LinkElement> links = new Dictionary<string, LinkElement>();
