    using System.Linq;
    using System.Xml.Linq;
    IEnumerable<string> GetProperties(XElement xml, string item1, string item2)
    {
        return xml.Element("tag2")
            .Elements("item_type1").Where(x => x.Attribute("name").Value == item1)
            .Elements("item_type2").Where(x => x.Attribute("name").Value == item2)
            .SelectMany(x => x.Elements("property").Select(p => p.Value));
    }
