       StringBuilder sb = new StringBuilder();
       using (StreamReader sr = new StreamReader("YourFile.xml")) 
       {
           String line;
           // Read and display lines from the file until the end of 
           // the file is reached.
           while ((line = sr.ReadLine()) != null) 
           {
               sb.AppendLine(line);
           }
        }
        string xmlString = sb.ToString();
        
        var doc = new XmlDocument();
        doc.Load(new StringReader(xmlString));
        
        XmlNodeList nodes = doc.GetElementsByTagName("Detail");
        foreach (XmlElement no in nodes)
        {
             XmlAttribute attr = doc.CreateAttribute("ISBN");
             attr.InnerText = "12345";
             no.Attributes.Append(attr);
        }
        using (StreamWriter writer = new StreamWriter("YourFile.xml", false))
        {
            writer.WriteLine(doc.ToString());
        }
