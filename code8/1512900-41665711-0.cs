    public partial class MainWindow : Window
    {
        private DisplayViewModel _displayThings = = new DisplayViewModel();
        private Affichage.MainWindow _displayer = new Affichage.MainWindow();
        public MainWindow()
        {
            InitializeComponent();
            _displayer.DataContext = _displayThings;
            _displayer.Show();
        }
        private void disp_btn_Click(object sender, RoutedEventArgs e)
        {
            _displayThings.TextToDisplay = textBox.Text;
        }
    }
