    public class Item
    {
        public string Name  { get; set; }
        public int Id       { get; set; }
        public int Balance  { get; set; }
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
