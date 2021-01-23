     public class Item
        {
            public string name { get; set; }
            public string code { get; set; }
            public int unit { get; set; }
            public double purchasePrice { get; set; }
            public double sellPrice { get; set; }
            public double averagePrice { get; set; }
        }
        
        public class MyTypeSummary
        {
            public string publicationDate { get; set; }
            public List<Item> items { get; set; }
        }
