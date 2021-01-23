    public class HtmlAttribute : IHtmlContent
    {
        public string Name { get; }
        public string Value { get; }
        public HtmlAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"{Name}=\"{Value}\"");
        }
    }
    public static class HtmlHelperExtensions
    {
        public static HtmlAttribute Attribute(this IHtmlHelper helper, string name, string value)
        {
            return new HtmlAttribute(name, value);
        }
    }
