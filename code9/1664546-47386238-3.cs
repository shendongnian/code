    [AddINotifyPropertyChangedInterface]
    public class MainPageModel : FreshBasePageModel
    {
        public MainPageModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Item("Item 1","First item"),
                new Item("Item 2","Second item"),
                new Item("Item 3","Third item"),
                new Item("Item 4","Fourth item"),
                new Item("Item 5","Fifth item")
            };
    
            SelectedItem = Items[2];
        }
    
        public ObservableCollection<Item> Items { get; set; }
    
        public Item SelectedItem { get; set; }
    }
