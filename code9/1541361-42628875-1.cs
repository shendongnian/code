    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Text { get; set; }
        public List<Item> Children { get; set; }
        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }
        public Item(string text)
        {
            Text = text;
        }
    }
    public partial class MainWindow : Window
    {
        public List<Item> Items { get; set; } = new List<Item>
        {
            new Item("1") { Children = new List<Item>
            {
                new Item("11"),
                new Item("12"),
                new Item("13"),
            }},
            new Item("2") { Children = new List<Item>
            {
                new Item("11"),
                new Item("12"),
                new Item("13"),
            }},
            new Item("3"),
        };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
