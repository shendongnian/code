    var doc = XDocument.Parse(yourXmlString);
    var groups = doc.Root
                    .Elements()
                    .GroupBy(element => new
                    {
                        Attrib1 = element.Attribute("Attrib1").Value,
                        Attrib2 = element.Attribute("Attrib2").Value,
                        Attrib3 = element.Attribute("Attrib3").Value,
                        Attrib4 = element.Attribute("Attrib4").Value,
                        Attrib5 = element.Attribute("Attrib5").Value
                    });
    var duplicates = group1.SelectMany(group => 
    {
        if(group.Count() == 1) // remove this if you want only duplicates
        {
            return group;
        }
        int minId = group.Min(element => int.Parse(element.Attribute("ID").Value));
        return group.Where(element => int.Parse(element.Attribute("ID").Value) > minId);
    });
