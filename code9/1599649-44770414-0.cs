    public class GridObject
    {
        public string Worker { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return ItemName;
        }
    
    }
