    XNamespace loNameSpace = "http://www.cpandl.com";
    XDocument loDoc = XDocument.Parse(Properties.Settings.Default.TransmitsData);
    
    var loReplyElement = loDoc.Element(loNameSpace.GetName("PurchaseOrder"))
        .Element(loNameSpace.GetName("frame"))
        .Element(loNameSpace.GetName("reply"));
    
    using (var loReader = loReplyElement.CreateReader())
    {
        var loSerializer = new XmlSerializer(typeof(Reply));
        var loReply = (Reply)loSerializer.Deserialize(loReader);
        Console.WriteLine(loReply.Id);
    }
