     static void generateReceipt(List<string> basket)
            {
                var itemsGroupped = from item in basket
                                      group item by item into g
                select new { Name = g.Key, Count = g.Count() };
    
                foreach (var item in itemsGroupped)
                {
                    Console.WriteLine(item.Count + "x ................ " + item.Name);
                }
    
            }
