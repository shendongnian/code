    StringReader stringReader = new StringReader(xmlString);
    XDocument document = XDocument.Load(stringReader);
    var node = document.Descendants("Product").FirstOrDefault(p => p.Descendants("Id").First().Value == "2");
    if(node != null)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Product));
        var xmlReader = new StringReader(node.ToString());
        Product result = serializer.Deserialize(xmlReader) as Product;
    }
