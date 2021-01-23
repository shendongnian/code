    void Main()
    {
    	var json = @"{ItemRelations: [
        {
            rel: ""System.Links.H-Forward"",
            source: {id: 123456,url: ""https://somename.domain.com/DefaultCollection/_apis/wit/Items/123456""},
            target: {id: 231856,url: ""https://somename.domain.com/DefaultCollection/_apis/wit/Items/231856""}
        }
    ]}";
    
        var parsed = JsonConvert.DeserializeObject<RootObject>(json);
    	
    	//Linqpad
    	//parsed.Dump();
    }
    
    public class Source
    {
        public int id { get; set; }
        public string url { get; set; }
    }
    
    public class Target
    {
        public int id { get; set; }
        public string url { get; set; }
    }
    
    public class ItemRelation
    {
    	public string rel { get; set; }
    	public Source source { get; set; }
    	public Target target { get; set; }
    }
    
    public class RootObject
    {
    	public List<ItemRelation> ItemRelations { get; set; }
    }
