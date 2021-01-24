    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private List<MyDataObject> L = new List<MyDataObject>
        {
            new MyDataObject {Amount = 1, Cost = 1, Gain = 1},
            new MyDataObject {Amount = 2, Cost = 2, Gain = 4},
            new MyDataObject {Amount = 3, Cost = 3, Gain = 9},
        };
        private void DisplayClick(object sender, RoutedEventArgs e)
        {
            Dg.ItemsSource = L;
        }
    }
   
