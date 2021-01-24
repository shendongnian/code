    List<ListingsModel> xlist = new List<ListingsModel>();
    
    XmlDocument doc = new XmlDocument();
    doc.Load(Server.MapPath("~/xml/listing.xml"));
    foreach (XmlNode node in doc.SelectNodes("/Listings/Listing"))
    {
        xlist.Add(new ListingsModel
        {
            Ad_Type = node["Type_Type"].InnerText,
            Unit_Type = node["Unit_Type"].InnerText
        });
    }
    
    AppTestDBConn db = new AppTestDBConn();
    db.AddRange(xlist);
    db.SaveChanges();
