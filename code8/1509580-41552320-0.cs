    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel();
        }
    }
    public class WindowViewModel
    {
        private readonly object _lock = new object();
        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
        public WindowViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(Items, _lock);
            Task.Run(() =>
            {
                for (int i = 0; i < 100; ++i)
                {
                    Items.Add(i.ToString());
                    Thread.Sleep(2000);
                }
            });
        }
    }
----------
    <ListBox ItemsSource="{Binding Items}"></ListBox>
