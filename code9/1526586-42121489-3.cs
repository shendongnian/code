    private static void WriteCustomDocumentProperty(Workbook workbook, string name, string value)
    {
        var ns = "urn:custom-storage:" + name;
        var document = new XDocument(new XElement(XName.Get("custom-storage", ns), value));
        var xmlValue = document.ToString();
        workbook.CustomXMLParts.Add(xmlValue);
    }
    private static string ReadCustomDocumentProperty(Workbook workbook, string name)
    {
        var ns = "urn:custom-storage:" + name;
        var parts = workbook.CustomXMLParts.SelectByNamespace(ns);
        switch (parts.Count)
        {
            case 0:
                return null;
            case 1:
                return XDocument.Parse(parts[1].XML).Root.Value;
            default:
                throw new ApplicationException("Duplicate part in workbook.");
        }
    }
