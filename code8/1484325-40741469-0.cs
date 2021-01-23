    public class SignedSamlXml : SignedXml
    {
        public SignedSamlXml()
        {
        }
        public SignedSamlXml(XmlDocument doc)
            : base(doc)
        {
        }
        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            var idElement = base.GetIdElement(document, idValue);
            if (idElement == null)
            {
                var attributes = document.SelectNodes("//@AssertionID");
                if (attributes == null) return null;
                foreach (XmlAttribute attr in attributes)
                {
                    if (attr.Value == idValue)
                    {
                        return attr.OwnerElement;
                    }
                }
            }
            return idElement;
        }
    }
