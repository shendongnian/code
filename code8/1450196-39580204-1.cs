    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.MaxHeight = SystemParameters.WorkArea.Height;
            this.MaxWidth = SystemParameters.WorkArea.Width;
            InitializeComponent();
        }
    }
