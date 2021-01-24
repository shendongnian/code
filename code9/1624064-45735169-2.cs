    public class DescriptionWriter : XmlTextWriter
    {
        public DescriptionWriter(string filename, Encoding encoding) : base(filename, encoding) { }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName, ns);
            var prop = typeof(Arm).GetProperty(localName);
            if (prop != null)
            {
                var data = prop.GetCustomAttributesData();
                var description = data.FirstOrDefault(a => a.AttributeType == typeof(XmlDescription));
                if (description != null)
                {
                    var value = description.NamedArguments.First().TypedValue.ToString().Trim('"');
                    base.WriteAttributeString("description", value);
                }
            }
        }
    }
