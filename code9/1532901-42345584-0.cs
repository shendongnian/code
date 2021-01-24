    public partial class WindowRegenboog : Window
    {
        public WindowRegenboog()
        {
            InitializeComponent();
            DropZone.ItemsSource = new List<Item> { new Item { Fill = Brushes.Red }, new Item() { Fill = Brushes.Yellow } };
        }
    }
