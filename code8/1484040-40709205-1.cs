    List<ListItem> list = new List<ListItem>();
    XDocument xDocument = XDocument.Load("Helpers/CachedResults/File.xml"); // load from file
    XElement root = xDocument.Element("list"); // get root element
    foreach (XElement xElement in root.Elements("list-item")) // traverse through elements inside root element
    {
        list.Add(new ListItem // add list items
        {
            ItemID = xElement.Attribute("id").Value, // parse id
            QuantitySold = Int32.Parse(xElement.Attribute("quantity-sold").Value), // parse int for QuantitySold
            GalleryURL = xElement.Attribute("gallery-url").Value // parse url
        });
    }
