    void Serializer_UnknownElement(object sender, XmlElementEventArgs e)
    {
        myClass my = (myClass)e.ObjectBeingDeserialized;
        if (e.Element.Name == "type1")
        {
            var ser = new XmlSerializer(typeof(myClass.Class1));
            using (var sr = new StringReader(e.Element.OuterXml))
                my.class1 = (myClass.Class1)ser.Deserialize(sr);
        }
        else if (e.Element.Name == "type2")
        {
            var ser = new XmlSerializer(typeof(myClass.Class2));
            using (var sr = new StringReader(e.Element.OuterXml))
                my.class2 = (myClass.Class2)ser.Deserialize(sr);
        }
    }
