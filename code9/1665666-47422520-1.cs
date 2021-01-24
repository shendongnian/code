    var xdoc = XDocument.Parse(xml);
    var obj = new
    {
        DATA = new
        {
            row = xdoc.Root
                      .Elements("row")
                      .Select(r => r.Elements()
                                    .ToDictionary(el => el.Name.LocalName, 
                                                  el => el.Value))
                      .ToList()
        }
    };
    JavaScriptSerializer jss = new JavaScriptSerializer();
    string json = jss.Serialize(obj);
