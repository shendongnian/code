    class Item
    {
        readonly string number;
        public Item(string number)
        {
            this.number = number;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }
        public override int GetHashCode()
        {
            return number?.GetHashCode() ?? 0;
        }
        private bool Equals(Item another)
        {
            if (another == null)
                return false;
            return number == another.number;
        }
    }
