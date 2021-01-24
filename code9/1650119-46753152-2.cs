    public partial class ChangeLocationWindow : Window
    {
        public ChangeLocationWindow()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.Instance.Location = "Test";
        }
    }
