    System.Xml.Linq.XElement body = System.Xml.Linq.XElement.Parse(msgCopy.GetReaderAtBodyContents().ReadInnerXml());
    var instance = Deserialize<OTA_HotelAvailRQ>(body, "http://www.opentravel.org/OTA/2003/05");
    public static T Deserialize<T>(XElement xElement, string nameSpace)
    {
        using (MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString())))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), nameSpace);
            return (T)xmlSerializer.Deserialize(memoryStream);
        }
    }
