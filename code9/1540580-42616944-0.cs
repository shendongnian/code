    public class TagUseCount
    {
        public int TagId { get; set; }
        public int UseCount { get; set; }
        public Tags Tag { get; set; }
        public enum Operation
        {
            None = 0,
            Increment = 2,
            Decrement = 4
        }
    }
