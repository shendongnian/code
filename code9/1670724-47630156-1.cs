    public class SelectionItem<TKey>
    {
        public TKey Key { get; set; }
        public string DisplayName { get; set; }
    }
    public class HomeEditViewModel : HomeEditPostModel
    {
        public IEnumerable<SelectionItem<int>> Town { get; set; }
        public IEnumerable<SelectionItem<int>> Street { get; set; }
        public IEnumerable<SelectionItem<int>> House { get; set; }
        public IEnumerable<SelectionItem<int>> Floor { get; set; }
    }
