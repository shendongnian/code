    public class dc
    {
        private static readonly dc _dc = new dc();
        public static dc Instance { get { return _dc;  } }
        
        public class TransactionTypeItem
        {
            public int ID { get; set; }
            public string Description { get; set; }
        }
        
        public static List<TransactionTypeItem> TransactionTypes
        {
            get
            {
                return new List<TransactionTypeItem>() { new TransactionTypeItem() { ID = 0, Description = "Zero" },
                                                        new TransactionTypeItem() { ID = 1, Description = "One" },
                                                        new TransactionTypeItem() { ID = 2, Description = "Two" } };
            }
        }
        public class DataItem
        {
            public TransactionTypeItem TransactionType { get; set; }
            public string OtherData { get; set; }
        }
        private List<DataItem> _items;
        public List<DataItem> DGItems
        {
            get
            {
                return _items;
            }
        }
             
        private dc()
        {
            _items = new List<DataItem>()
            {
                new DataItem() { OtherData = "Test0", TransactionType = TransactionTypes[0] },
                new DataItem() { OtherData = "Test1", TransactionType = TransactionTypes[1] },
                new DataItem() { OtherData = "Test2", TransactionType = TransactionTypes[2] },
            };
        }
    }
