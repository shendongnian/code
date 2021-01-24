    public class DataItem
    {
        public String N { get; set; }
        public int C { get; set; }
        //use an Item property to reference itself
        public DataItem Item { get { return this; } }
    }
