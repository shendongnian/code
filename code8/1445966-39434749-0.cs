    public partial class MainWindow : Window
    {
        WrenchViewModel wrench;
        public MainWindow()
        {
            InitializeComponent();
            wrench = new WrenchViewModel();
