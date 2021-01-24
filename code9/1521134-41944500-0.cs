    // Content item for the combo box
    private class Item
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        private Item(string _name, int _value)
        {
            Name = _name; Value = _value;
        }
    }
