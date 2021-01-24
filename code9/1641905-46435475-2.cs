    [XmlRoot("OutlTxt", Namespace = OutlineText.Namespace)]
    public class OutlineText
    {
        public const string Namespace = "http://www.mynamespace/09262017";
        private string _value;
        [XmlAnyElement("TextOutlTxt", Namespace = OutlineText.Namespace)]
        public XElement Value
        {
            get
            {
                var escapedValue = EscapeTextValue(_value);
                var nestedXml = string.Format("<p xmlns=\"{0}\" style=\"text-align:left;margin-top:0pt;margin-bottom:0pt;\"><span>{1}</span></p>", Namespace, escapedValue);
                var outerXml = string.Format("<TextOutlTxt xmlns=\"{0}\">{1}</TextOutlTxt>", Namespace, nestedXml);
                var element = XElement.Parse(outerXml);
                //Remove redundant xmlns attributes
                element.DescendantsAndSelf().SelectMany(e => e.Attributes()).Where(a => a.IsNamespaceDeclaration && a.Value == Namespace).Remove();
                return element;
            }
            set
            {
                _value = value == null ? null : value.ToString();
            }
        }
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
    }
