            public static string RemoveAllNamespaces(string xmlDocument)
            {
                XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));
    
                return xmlDocumentWithoutNs.ToString();
            }
            private static XElement RemoveAllNamespaces(XElement xmlDocument)
            {
                if (!xmlDocument.HasElements)
                {
                    XElement xElement = new XElement(xmlDocument.Name.LocalName);
                    xElement.Value = xmlDocument.Value;
    
                    foreach (XAttribute attribute in xmlDocument.Attributes())
                        xElement.Add(attribute);
    
                    return xElement;
                }
                return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
            }
