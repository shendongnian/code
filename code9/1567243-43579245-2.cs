    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Item> Items;
    
        public MainPage()
        {
            this.InitializeComponent();
            Items = new ObservableCollection<Item>();
            Item item1 = new Item();
            item1.Name = "Item 1";
            Items.Add(item1);
            MyListView.ItemsSource = Items;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Item item2 = new Item();
            item2.Name = "Item 2";
            Items.Add(item2);
        }
    }
    
    public class Item
    {
        public string Name { get; set; }
    }
