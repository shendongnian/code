           public static void CreateItemsList(List<Item> itemsList)
            {
                var doc = XDocument.Load(FILENAME);
                var item = doc.Root
                    .Descendants("ITEM")
                    .Select(node => new Item()
                    {
                        ItemName = (string)node.Element("ITEMNAME"),
                        ItemPrice = (decimal)node.Element("ITEMPRICE")
                    })
                    .ToList();
                Console.WriteLine(string.Join(",",item.Select(x => x.ToString())));
            }
