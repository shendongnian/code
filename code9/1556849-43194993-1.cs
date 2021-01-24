    public class Content
    {
        public string Content { get; set; }
    }
    public class Stuff
    {
        public List<Content> Contents { get; set; }
    }
    
    public class ThingContainer
    {
        public List<Stuff> Stuffs { get; set; }
    }
