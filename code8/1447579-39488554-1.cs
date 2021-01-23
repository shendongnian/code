    public partial class MainWindow : Window
    {
        public ObservableCollection<MyObject> MyObjects { get; } = new ObservableCollection<MyObject>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            // find the (static)resource
            var colors = (ErrorColors)FindResource("Colors");
            colors.ERROR = new SolidColorBrush(Colors.Red);
            colors.WARNING = new SolidColorBrush(Colors.Orange);
            colors.INFORMATION = new SolidColorBrush(Colors.Lime);
            // Add objects to the list
            MyObjects.Add(new MyObject { Title = "This is an error", ErrorLevel = ErrorLevel.Error });
            MyObjects.Add(new MyObject { Title = "This is a warning", ErrorLevel = ErrorLevel.Warning });
            MyObjects.Add(new MyObject { Title = "This is information", ErrorLevel = ErrorLevel.Information });
        }
    }
