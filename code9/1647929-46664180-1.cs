    public partial class MainWindow : Window
    {
        public ObservableCollection<myItem> Item { get; private set; }
        const string pattern = @"((.*)) (.*) left the game";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Item = new ObservableCollection<myItem>() { new myItem() { Username = "Prabhat" } };
        }
    }
