    public partial class ItemTabItem : TabItem
    {
        private Item item;
        public ItemTabItem() => InitializeComponent();
        public Item Item
        {
            get => item;
            set
            {
                item = value;
                DataContext = value;
                Header = item?.Name;
            }
        }
    }
