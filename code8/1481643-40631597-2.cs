    public class HtmlAttribute : IHtmlString
    {
        public string Name { get; }
        public string Value { get; }
        
        public HtmlAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
        
        public override string ToHtmlString()
        {
            return $"{Name}=\"{Value}\"";
        }
    }
    
    public static HtmlHelperExtensions
    {
        public static HtmlAttribute Attribute(this HtmlHelper helper, string name, string value)
        {
            return new HtmlAttribute(name, value);
        }
    }
