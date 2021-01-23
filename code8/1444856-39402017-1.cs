    IEnumerable<XElement> result = from d in doc.Descendants("team")
                                   where d.Descendants()
                                       .Any(c => people.Contains(c.Name.LocalName))
                                   select d;
    foreach (XElement element in result)
    {
        foreach (XElement child in element.Descendants().ToList())
        {
            if (!people.Contains(child.Name.LocalName))
            {
                child.Remove();
            }
        }
    }
