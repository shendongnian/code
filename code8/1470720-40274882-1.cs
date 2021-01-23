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
            // this is c# 6 feature 
            return number?.GetHashCode() ?? 0;
            // If you are not using c# 6, you can use
            // return number == null ? 0 : number.GetHashCode();
        }
        private bool Equals(Item another)
        {
            if (another == null)
                return false;
            return number == another.number;
        }
    }
