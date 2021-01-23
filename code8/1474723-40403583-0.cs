    var doc = XElement.Load("your.xml");
    var dict = doc.Elements("Requirement")
        .Elements("ID")
        .GroupBy(id => id.Value)
        .ToDictionary(id => id.Key, id => new { Id = 1, Count = id.Count() });
    foreach (var req in doc.Elements("Requirement"))
    {
        var id = req.Element("ID").Value;
        var a = dict[id];
        if (a.Count > 1)
        {
            foreach (var elem in req.Elements())
            {
                elem.Add(new XAttribute("id", a.Id));
            }
            dict[id] = new { Id = a.Id + 1, a.Count };
        }
    }
