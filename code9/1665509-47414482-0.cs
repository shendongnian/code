    public class ContentJsonNew
    {
        public List<Section> Sections { get; set; }
    }
    
    public class Section
    {
        public List<Content> Content { get; set; }
    }
    
    public class Content
    {
        public List<Content2> ContentToSearch { get; set; }
    }
    
    public class Content2 {
    public string Type { get; set; }
    //other properties
    }
