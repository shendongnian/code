    public class Item
    {
        public string Id { get; set; }
        public MyType Type { get; set; }
        public bool IsValid
        {
            get
            {
                const int REQUIRED_TYPES = 7;
                var result = (int)item.Type & REQUIRED_TYPES;
                return result > 0;
            }
        }
        // You can make adding types in more readable way
        public void AddType(MyType type)
        {
            Type |= type;
        }
    }
