    public static void CreateItemsList(ref List<Item> itemsList)
            {
                var doc = XDocument.Load(@"..\..\ItemsXML.xml");
    
                itemsList = doc.Root
                    .Descendants("ITEM")
                    .Select(node => new Item
                    {
                        ItemName = node.Element("ITEMNAME").Value,
                        ItemPrice = decimal.Parse(node.Element("ITEMPRICE").Value)
                    })
                    .ToList();
    
                Console.WriteLine(string.Join(",", itemsList.Select(x => x.ToString())));
    
            }
