    [Serializable]
    public class Item
    {
        public string Name;
        public int Id;
        public int Balance;
    
        public Item()
        {
    
        }
    
        public Item(string name1, int id1, int balance1)
        {
            Name = name1;
            Id = id1;
            Balance = balance1;
        }
    }
