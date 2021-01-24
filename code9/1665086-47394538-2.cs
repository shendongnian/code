    public partial class TestWindow : Window
    {
        public decimal Total
        {
            get
            {
                if (string.IsNullOrEmpty(txtDisplayAmount))
                    return 0M;
                decimal d;
                decimal.TryParse(txtDisplayAmount.Text, out d);
                return d;
            }
            set { txtDisplayAmount.Text = value.ToString(); }
        }
        public TestWindow()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
