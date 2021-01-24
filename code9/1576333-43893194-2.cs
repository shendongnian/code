    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
    public class MainViewModel
    {
        public ObservableCollection<Error> ErrorLog { get; set; } = new ObservableCollection<Error>
                                                                        {
                                                                            new Error("A"),
                                                                            new Error("B"),
                                                                        };
    }
    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
