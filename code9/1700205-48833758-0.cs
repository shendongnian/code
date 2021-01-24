    public class Info
    {
        public List<Item> GetItemInfo(string Attribute = null)
        {
            List<Item> itemList = new List<Item>
            {
                new Item { Name = "Wrench",  ID = 0, Attributes = new List<string> { "Tool"  } },
                new Item { Name = "Pear",    ID = 1, Attributes = new List<string> { "Fruit" } },
                new Item { Name = "Apple",   ID = 2, Attributes = new List<string> { "Fruit" } },
                new Item { Name = "Drill",   ID = 3, Attributes = new List<string> { "Tool",   "Power"  } },
                new Item { Name = "Bear",    ID = 4, Attributes = new List<string> { "Animal", "Mammal" } },
                new Item { Name = "Shark",   ID = 5, Attributes = new List<string> { "Animal", "Fish"   } }
            };
            // If no Attribute specified, return the entire item list
            if (Attribute == null) return itemList;
            // Otherwise, filter by the Attribute specified
            else return itemList.Where(i => i.Attributes.Contains(Attribute)).ToList();
        }
    }
