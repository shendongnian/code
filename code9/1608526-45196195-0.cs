        static void Main(string[] args)
        {
            using (FileStream existingPdf = new FileStream(SRC, FileMode.Open))
            using (PdfReader pdfReader = new PdfReader(existingPdf))
            using (FileStream targetPdf = new FileStream(Target, FileMode.Create))
            {
                PdfReader.unethicalreading = true;
                using (PdfStamper stamper = new PdfStamper(pdfReader, targetPdf, '\0', true))
                {
                    XfaForm form = new XfaForm(pdfReader);
                    XDocument xdoc = form.DomDocument.ToXDocument();
                    var nodeElements = from nodeElement in xdoc.Descendants("form1").Descendants("A1")
                                       select nodeElement;
                    foreach (XElement singleNodeElement in nodeElements)
                    {
                        if (singleNodeElement.Name == "A1")
                        {
                            singleNodeElement.Value = "LOLGG";
                        }
                    }
                    XmlDocument xmlDoc = xdoc.ToXmlDocument();
                    XmlNamespaceManager namespaces = new XmlNamespaceManager(xmlDoc.NameTable);
                    namespaces.AddNamespace("xfa", "http://www.xfa.org/schema/xfa-data/1.0/");
                    XmlNode baseNode = xmlDoc.SelectSingleNode("//xfa:datasets", namespaces);
                    stamper.AcroFields.Xfa.FillXfaForm(baseNode);
                }
            }
        }
    }
    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
