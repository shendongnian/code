    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ItemsPresenter_KeyUp(object sender, KeyEventArgs e)
        {
            cbx1.SelectedItem = e.OriginalSource;
        }
    }
