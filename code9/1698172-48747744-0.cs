     XmlDocument xml = new XmlDocument();
     xml.Load(@"C:\Sample.xml");
     XmlNodeList xnList = xml.SelectNodes("names/file/name");
     foreach (XmlNode xn in xnList)
     {
         Console.WriteLine(xn.InnerText);
     }
    // outputs,
    // Test name 1
    // Test name 2
    // Test name 3
