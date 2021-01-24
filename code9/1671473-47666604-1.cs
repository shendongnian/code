    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            MyItems = new List<ViewItem>();
            for (int i = 0; i < 10; i++)
                MyItems.Add(new ViewItem { Id = i, AllowDrop = i % 2 == 0 });
        }
        public List<ViewItem> MyItems { get; set; }
    }
    public class ViewItem
    {
        public int Id { get; set; }
        public bool AllowDrop { get; set; }
    }
