    public class Item
    {
        public int Prop1 { get; set; }
    
        public Item(int value)
        {
            Prop1 = value;
        }
    
        public static Item Create(string value)
        {
            int i;
            return int.TryParse(value, out i) ? new Item(i) : null;
        }
    }
