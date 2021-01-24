    public class Content
    {
        public List<string> Content { get; set; }
    }
    public class Stuff
    {
        public List<Content> Contents { get; set; }
    }
    
    public class ThingContainer
    {
        public List<Stuff> Stuffs { get; set; }
    }
