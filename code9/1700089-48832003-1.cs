    using (var nodeReader = new XmlNodeReader(xmldoc))
    {
        nodeReader.MoveToContent();
        XDocument xdoc = XDocument.Load(nodeReader);
        List<dynamic> elements =
        (
            from item in xdoc.Descendants("s")
            select new
            {
                Begin = (item.FirstNode as XElement).LastAttribute.Value,
                Last = (item.LastNode as XElement).LastAttribute.Value,
                NodeValueInArray = item.Descendants("w").Select(q => q.Value).ToArray(),
                NodeValuesCommaSeparated = string.Join(" ", item.Descendants("w").Select(q => q.Value).ToArray())
            }
        ).ToList<dynamic>();
    }
