    values = XDocument.Load(filePath)
      .DescendantNodes()
      .Select(dn => dn as XElement)
      .Where(xe => xe?.Name == "data")
      .Select(xe => new new ResxString
      {
             LineKey = element.Attribute("name").Value,
             LineValue = element.Value.Trim(),
             LineComment = element.Element("comment")?.Value 
      })
      .ToList();  // or to array or whatever
