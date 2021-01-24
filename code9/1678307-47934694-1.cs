    namespace WpfApplication1 {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window {
            private MainViewModel viewModel;
    
            public MainWindow() {
                InitializeComponent();
                viewModel = new MainViewModel() {
                    Items = new List<string>() {
                         "a", "b"
                    }
                };
                this.DataContext = viewModel;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e) {
                viewModel.FillItems();
            }
        }
    
        public class MainViewModel : INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChangedEvent(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Random random = new Random();
            
            private List<string> items = new List<string>();
            public List<string> Items {
                get {
                    return items;
                }
                set {
                    items = value;
                    RaisePropertyChangedEvent(nameof(Items));
                }
            }
    
            public void FillItems() {    
                var list = Enumerable.Range(0, 10).Select(i => random.Next(100).ToString()).Distinct().ToList();
                Items = new List<string>(list);
            }
        }
    }
