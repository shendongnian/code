    private static void NestedMemberSerialization()
    {
    
        var serializedXml = "<ClassA2><ID>1</ID><Details><ClassA1><ID>2</ID><Name>4</Name><Value>2</Value><Description>3</Description></ClassA1></Details><SomeValue>2</SomeValue></ClassA2>";
    
        XDocument doc = XDocument.Parse(serializedXml);
    
        var mySteps = (from s in doc.Descendants("ClassA2")
                       select new ClassA2
                       {
                           ID = decimal.Parse( s.Element("ID").Value),
                           SomeValue = int.Parse( s.Element("SomeValue").Value),
                           Details = new ClassA1 { ID = decimal.Parse(s.Element("Details").Descendants("ClassA1").Descendants("ID").ElementAt(0).Value) }
                       }).ToList();
    
    }
