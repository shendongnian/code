    // using System.Data.SqlTypes;
    // using System.IO;
    // using System.Xml;
    static SqlXml GetXml(string s)
    {
        return new SqlXml(XmlReader.Create(new StringReader(s)));
    }
