    [XmlRoot("OutlTxt", Namespace = OutlineText.Namespace)]
    public class OutlineText : IXmlSerializable
    {
        public const string Namespace = "http://www.mynamespace/09262017";
        private string _value;
        // For debugging purposes.
        internal string InnerValue { get { return _value; } }
        static string EscapeTextValue(string text)
        {
            return Regex.Replace(text, @"[\a\b\f\n\r\t\v\\""'&<>]", m => string.Join(string.Empty, m.Value.Select(c => string.Format("&#x{0:X};", Convert.ToInt32(c))).ToArray()));
        }
        private OutlineText()
        { }
        public OutlineText(string text)
        {
            _value = text;
        }
        #region IXmlSerializable Members
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            _value = ((XElement)XNode.ReadFrom(reader)).Value;
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            var escapedValue = EscapeTextValue(_value);
            var nestedXml = string.Format("<p style=\"text-align:left;margin-top:0pt;margin-bottom:0pt;\"><span>{0}</span></p>", escapedValue);
            writer.WriteRaw(nestedXml);
        }
        #endregion
    }
