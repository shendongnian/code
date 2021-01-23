    string xml = "<parent><items>" +
                 "<book>" +
                 "<pen>" +
                 "</pen>" +
                 "</book>" +
                  "</items></parent>";
    
                
    
     XDocument doc = XDocument.Parse(xml);
     Console.WriteLine(doc.ToString());
     var books = doc.Descendants("items").Elements().First();
     doc.Element("parent").Element("items").Element("book").Remove();
     doc.Element("parent").Element("items").Add(new XElement("paper",books));
    
                
    Console.WriteLine(doc.ToString());
