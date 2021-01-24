    var xDoc1 = XDocument.Load(/* xml path */);
    var nodes = xDoc1.Root.Elements("Nice");
    var values = nodes
        .Where(n => n.Attributes.Any(a => a.Name == "to"))
        .Select(n => {
          int result;
          int.TryParse(n.Attribute.First(n.Attributes.First(a => a.Name == "to"), out result);
          return result;
        })
        .ToList();
    values.AddRange(
        .Where(n => n.Attributes.Any(a => a.Name == "from"))
        .Select(n => {
          int result;
          int.TryParse(n.Attribute.First(n.Attributes.First(a => a.Name == "from"), out result);
          return result;
        })
        .ToList());
    values = values.OrderBy(n => n).ToList();
