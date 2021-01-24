    //You can also use Load(), this is just so I didn't have to make a file
    XDocument doc = XDocument.Parse("<Toolings><Testing><Test><ID>1234</ID></Test></Testing></Toolings>");
    
    //Grab the first Test node (change the predicate if you have other search criteria)
    var elTest = doc.Descendants().First(d => d.Name == "Test");
    
    //Copy the node, only necessary if you don't know the structure at design time
    XElement el = new XElement(elTest);
    
    el.Element("ID").Value = "5678";
    
    //inject new node 
    elTest.AddAfterSelf(el);
    
    doc.Save("After.xml");
