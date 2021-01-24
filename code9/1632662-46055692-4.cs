    // Load xml
    XElement doc = XElement.Load("http://.../file.xml");
    //using linq to get all nodes with name 'oldName'
    var nodes = doc.Descendants().Where(element => element.Name.LocalName.Equals("oldName"));
    foreach (var element in nodes)
    {
      if (element.Name.LocalName.Equals("oldName"))
      {
       element.Name = "newName";
      }
    }
    //get all newName nodes
    var newNodes = doc.Descendants().Where(element => element.Name.LocalName.Equals("newName"));
    
    XElement newDoc = new XElement("item", newNodes);
    // Save xml
    newDoc.Save("C:/newFile.xml");
