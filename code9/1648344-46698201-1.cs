    // for root menu
    public class Category
    {
        public string CategoryName { get; }
        public string DisplayName => CategoryName;
        ...
    }
    
    // for submenus
    public class Item
    {
        public string DisplayName { get; }
        ...
    }
