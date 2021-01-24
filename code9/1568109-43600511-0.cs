    internal class CountableItem
    {
        private string _itemName;
        private int _count;
    
        public CountableItem(string itemName)
        {
            _itemName = itemName;
            _count = 1;
        }
    
        public void Increment()
        {
            _count++;
        }
    
        public override string ToString()
        {
            return String.Format("{0} x {1}", _itemName, _count);
        }
    }
