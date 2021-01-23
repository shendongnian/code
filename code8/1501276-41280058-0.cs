    string pathToXmlFile = ""; // point to your xml file ... 
    using (StreamReader reader = File.OpenText(pathToXmlFile))
    {
        XDocument doc = XDocument.Load(reader); // load into XDocument
        XElement idElement = doc.Root.Element("Session").Elements("Message").Elements("ID").First( item => item.Value == "1"); // since you need the message id = 1
        string content = idElement.Parent.Element("Content").Value; // get the parent of this message id which is message element then navigate to its content element.
    }
  
