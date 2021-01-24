    public class Item
    {
        public int Id { get; set; }
        public bool ShouldSerializeId()
        {
            return false;
        }
    }
