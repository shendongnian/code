    XDocument xdoc = XDocument.Load("asd.xml");
    string yourCondition = "Test2";
    var query = from elem in xdoc.Root.Elements("Row")
                where elem.Element("FolderName").Value == yourCondition
                select new
                {
                    FileTypeId = elem.Element("FileTypeId").Value,
                    EngName = elem.Element("EngName").Value,
                    JpnName = elem.Element("JpnName").Value
                };
    if (query.Count() > 0)
    {
        var result = query.First();
        // You can access the fields through this:
        string engName = result.EngName;
        string fileTypeId = result.FileTypeId;
        string jpnName = result.JpnName;
    }
