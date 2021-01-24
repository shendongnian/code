    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ObservableCollection<string>();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new Window1();
            window1.ItemAddedEvent += ItemAddedEventHandler;
            window1.Show();
        }
        private void ItemAddedEventHandler(object sender, NameAddedEventArgs e)
        {
            (DataContext as ObservableCollection<string>).Add(e.NewName);
        }
    }
