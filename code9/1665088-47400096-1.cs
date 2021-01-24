    public partial class TestWindow : Window
    {
        public decimal Total;
        public TestWindow()
        {
            InitializeComponent();
            txtDisplayAmount.Text = ((MainWindow)Application.Current.MainWindow).sum.ToString();
        }
        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
            // TODO: Add event handler implementation here.
        }
    }
