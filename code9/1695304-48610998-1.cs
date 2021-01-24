	public class AddressBuilder
    {
        private readonly List<int> _items = new List<int>();
        public AddressBuilder Add(params int[] items)
        {
            _items.AddRange(items);
            return this;
        }
        public int[] Build()
        {
            //whatever you need to do here
            return _items.ToArray();
        }
    }
