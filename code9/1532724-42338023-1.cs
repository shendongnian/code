    using (System.IO.TextWriter writer = new System.IO.StreamWriter(@"C:\temp\test.xml"))
    {
          System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(UIColor));
          System.Xml.Serialization.XmlSerializerNamespaces namspace = new XmlSerializerNamespaces();
          namspace.Add("", "");
          xml.Serialize(writer, new UIColor(), namspace);
    }
