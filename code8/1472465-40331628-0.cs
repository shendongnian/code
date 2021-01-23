        class BaseClass { }
    class RootObject: BaseClass { }
    class LineItem : BaseClass { }
    class MainViewModel
    {
        public List<LineItem> ProductList { get; set; }
        public List<RootObject> OrdersList { get; set; }
        public BaseClass LeftListViewSelectedItem { get; set; }
    }
