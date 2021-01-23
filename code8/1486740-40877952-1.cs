    public abstract class RootBase
    {
        public Header header { get; set; }
        [XmlIgnore]
        // The following provides get-only access to the specific content of this root
        public abstract ContentBase BasicContent { get; }
    }
    public class Header
    {
        public string elementA { get; set; }
        public string elementB { get; set; }
    }
    [XmlRoot(ElementName = "root")]
    public class Root<TContent> : RootBase 
        where TContent : ContentBase
    {
        public TContent content { get; set; }
        public override ContentBase BasicContent { get { return content; } }
    }
