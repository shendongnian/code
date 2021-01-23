    using (StringReader reader = new StringReader(myXmlString))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(BIObjects));
        var objs = (BIObjects)serializer.Deserialize(reader);
        
        // use results
        // foreach(BIObject obj in objs.Objects)
    }
