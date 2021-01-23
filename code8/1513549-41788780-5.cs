    public class Address : IFormattable
    {
        public string Recipient { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        ....
        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            // http://stackoverflow.com/questions/3179716/how-determine-if-application-is-web-application
            if ((format == null && InWebContext) || format == "H")
                return string.Join("<br/>", Recipient, Line1, Line2, ZipCode + " " + City, Country);
            return string.Join(Environment.NewLine, Recipient, Line1, Line2, ZipCode + " " + City, Country);
        }
    }
