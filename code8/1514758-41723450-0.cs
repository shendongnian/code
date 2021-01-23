    internal class RpsSignedXml : SignedXml
    {
        // ctors and other members as appropriate
        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            if (document == null)
                return null;
            if (string.IsNullOrEmpty(idValue))
                return null;
            if (!idValue.StartsWith("rps:"))
                return base.GetIdElement(document, idValue);
            string xPath = $"//InfRps[@Id=\"{idValue}\"]";
            XmlNodeList nodeList = document.SelectNodes(xPath);
            if (nodeList == null || nodeList.Count != 1)
                return null;
            return nodeList[0] as XmlElement;
        }
    }
