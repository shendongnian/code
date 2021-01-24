    string xml = @"<?xml version=""1.0""?>
        <Item Number = ""100"" ItemName = ""TestName1"" ItemId = ""1"" />";
    
    XDocument doc = XDocument.Parse(xml);
    
    var item = ChoXmlReader<Item>.LoadXElements(new XElement[] { doc.Root }).FirstOrDefault();
    Console.WriteLine($"ItemId: {item.ItemId}");
    Console.WriteLine($"ItemName: {item.ItemName}");
    Console.WriteLine($"Number: {item.Number}");
    Console.WriteLine($"Created: {item.Created}");
