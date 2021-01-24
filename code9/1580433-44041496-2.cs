    internal class GroceryItem
        {
            private readonly string _description;
            public GroceryItem(string description)
            {
                _description = description;   // We can set this in ctor
            }
            public string Description
            {
                get { return _description; }
            }
        }
