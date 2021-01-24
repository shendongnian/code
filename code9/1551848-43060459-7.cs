    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            Items.Add("Item #1");
            Items.Add("Item #2");
            Items.Add("Item #3");
        }
        private static readonly Random _random = new Random();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Items.Count > 0 ? _random.Next(2) : 0)
            {
                case 0: // add
                    Items.Insert(_random.Next(Items.Count + 1), $"Item #{_random.Next()}");
                    break;
                case 1: // remove
                    Items.RemoveAt(_random.Next(Items.Count));
                    break;
            }
        }
    }
