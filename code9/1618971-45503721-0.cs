      string path = @"D:\1.txt";
      XDocument _doc = XDocument.Load(path);
    
      List<XElement> testIds = new List<XElement>();
     
      testIds = _doc.Descendants("test").ToList();
    
     
      foreach (XElement extId in testIds.Distinct())
      {
         // get element values
            string id = extId.Attribute("id").Value;
            string name = extId.Element("name").Value;
            string age = extId.Element("age").Value;
            string info = extId.Element("informations").Value;
            Console.WriteLine(name + ", " + " " + age + ", " + info);
      }
