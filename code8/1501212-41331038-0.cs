    using (var dbcontext = new DbContext())
    {
        //Reading stored procedure results as List<string>
        var r = dbcontext.Database.SqlQuery<string>("EXEC xml_test").ToList();
        //Joining strings to one string that causes in resulting long strings
        var xmlString = string.Join("", r);
        //Now you can load your string to a XmlDocument
        var xml = new XmlDocument();
        //Note: You need to add a root element to your result
        xml.LoadXml($"<root>{xmlString}</root>");
    }
