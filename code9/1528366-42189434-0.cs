    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = Enumerable.Range(0, 1); //returns an IEnumerable<int> with a single int -> one row will be rendered
        }
    }
