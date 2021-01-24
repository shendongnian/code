    class TableItem
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public TableItem() { }
        public TableItem(string property1, string property2, string property3)
        {
            Property1 = property1;
            Property2 = property2;
            Property3 = property3;
        }
    }
    class ViewModel
    {
        public ObservableCollection<TableItem> TableItems { get; } = new ObservableCollection<TableItem>();
    }
