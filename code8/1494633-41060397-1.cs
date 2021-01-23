    public partial class MainWindow : Window
    {
        MyViewModel vm;
        int i;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MyViewModel();
            DataContext = vm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.MyGraph.Add(new KeyValuePair<DateTime, int>(DateTime.Now.AddDays(i), i * 100));
            i++;
        }
    }
