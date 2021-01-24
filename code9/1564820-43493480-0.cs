    string xml = "<Tables><StaticGroups><StaticGroup Name=\"111\"><Table><TableName>Table1 Name</TableName><TableTag>Table1 Tag</TableTag></Table><StaticGroup Name=\"111.1\"><Table><TableName>Table1.1 Name</TableName><TableTag>Table1.1 Tag</TableTag></Table></StaticGroup></StaticGroup></StaticGroups></Tables>";
    XmlSerializer serializer = new XmlSerializer(typeof(TablesXML));
    TablesXML tablesXml;
    using (TextReader reader = new StringReader(xml))
    {
        tablesXml = (TablesXML)serializer.Deserialize(reader);
    }
