	public class MainItems
    {
        public string ItemName { get; set; }
        public ObservableCollection<SubItems> SubItemsList { get; set; }
    }
    public class SubItems
    {
        public string SubItemName { get; set; }
    }
