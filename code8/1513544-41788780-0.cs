    public class Person : IFormattable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            // reroute standard method to IFormattable one
            return ToString(null, null);
        }
        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return Name;
        
            if (format == "I")
                return Id;
            // note WebUtility is now defined in System.Net so you don't need a reference on "web" oriented assemblies
            if (format == "A")
                return string.Format(formatProvider, "<a href='/People/Detail/{0}'>{1}</a>", WebUtility.UrlEncode(Id), WebUtility.HtmlDecode(Name));
            // implement other smart formats
            return Name;
        }
    }
    
