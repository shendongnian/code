    public partial class MainWindow : Window
    {
        public MyModel MyModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MyModel = new MyModel();
        }
    }
