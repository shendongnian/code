    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.PrimaryScreenHeight - SystemParameters.CaptionHeight;
            MaxWidth = SystemParameters.PrimaryScreenWidth;
        }
    }
