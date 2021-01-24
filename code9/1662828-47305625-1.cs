    public class LinkElement
    {
        public string Key { get; set; }
        public LinkElementInfo Info { get; set; }
    }
    
    public class LinkElementInfo 
    {
       public string Link { get; set; }
    
       public string Description { get; set; }
    
       public string Type { get; set; }
    
       public string[] Tags { get; set; }
    }
    //Example Data
    Dictionary<string, LinkElementInfo> links = new Dictionary<string, LinkElementInfo>()
    {
      {'a',{...}}
    };
