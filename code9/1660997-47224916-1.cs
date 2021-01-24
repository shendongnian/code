    public partial class MainWindow : Window
    {
        private Form winForm;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            winForm = new WinForm1();
            winForm.Show();
        }
    }
