        var document = XDocument.Parse(xmlString);
        var historyObject2 = document.Root.Descendants()
            .Where(x=>x.Name.LocalName == "History")
            .Select(historyElement => new History
            {
                Name = historyElement.Element(historyElement.Name.Namespace + "Name")?.Value,
                Number = historyElement.Element(historyElement.Name.Namespace+ "Number")?.Value,
                Items = historyElement.Elements(historyElement.Name.Namespace + "Item").Select(x => new Item()
                {
                    //CreateDate = DateTime.Parse(x.Element("CreateDate")?.Value),
                    Type = x.Element(historyElement.Name.Namespace + "Type")?.Value,
                    Description = string.Join(",", x.Elements(historyElement.Name.Namespace + "Description").Select(elem => elem.Value))
                }).ToList()
            }).FirstOrDefault();
