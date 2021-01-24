    public class ViewModel : ObservableCollection<ListItem>
    {
        public ViewModel()
        {
            populateItems();
            CollectionViewSource.GetDefaultView(this).SortDescriptions.Add(new SortDescription("Item.Content", ListSortDirection.Ascending));
        }
        private void populateItems()
        {
            addOneItem(0, "zero");
            addOneItem(1, "one");
            addOneItem(2, "two");
            addOneItem(3, "three");
            addOneItem(4, "four");
        }
        private void addOneItem(int img, string content)
        {
            ListItem item = new ListItem();
            item.Image = img;
            item.Item = new SomeItem { Content = content };
            Add(item);
        }
    }
    public class ListItem
    {
        public int Image { get; set; }
        public SomeItem Item { get; set; }
    }
    public class SomeItem
    {
        public string Content { get; set; }
    }
