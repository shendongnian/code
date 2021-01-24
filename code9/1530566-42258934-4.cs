    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ellipse.DataContext = new MyCommPort();
        }
    }
