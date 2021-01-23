    List<ListItem> list = new List<ListItem>();
    // (the list is populated)
    XDocument xDocument = new XDocument(); // create empty document
    XElement root = new XElement("list"); // add root element, XML requires one single root element
    xDocument.Add(root); // add root to document
    foreach(var listItem in list) 
    {
        var xElement = new XElement("list-item", // <list-item />
            new XAttribute("id", listItem.ItemID), // id="id"
            new XAttribute("quantity-sold", listItem.QuantitySold), // quantity-sold=5
            new XAttribute("gallery-url", listItem.GalleryURL) // gallery-url="foo/bar"
        );
        root.Add(xElement); // add list-item element to root
    }
    xDocument.Save("Helpers/CachedResults/File.xml"); // save file
