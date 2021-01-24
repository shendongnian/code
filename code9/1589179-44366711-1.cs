    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            MyItems = new List<DisplayableItem>
            {
                new DisplayableItem { FirstProperty = "Some string" },
                new DisplayableItem { FirstProperty = 60 },
                new DisplayableItem { FirstProperty = "Also a string" },
            };
        }
        public IEnumerable<DisplayableItem> MyItems { get; }
    }
    public class DisplayableItem
    {
        public object FirstProperty { get; set; }
        public bool HasCombobox => !(FirstProperty is string);
    }
