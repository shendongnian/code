    [System.Xml.Serialization.XmlRoot("Request")]
    public class GenericRequest
    {
      public GenericRequest()
      {
      }
    
    
      public int RequestType { get; set; }
    
      public string User { get; set; }
    
      public int id { get; set; }
    
      public IFooter Footer { get; set; }
    }
