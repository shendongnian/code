    public partial class PlayPage : Page
    {
        public PlayPage()
        {
            InitializeComponent();
        }
        private void Clicker_Sub_Click(object sender, RoutedEventArgs e)
        {
            Swag.Reduce(1);
        }
        private void Clicker_Add_Click(object sender, RoutedEventArgs e)
        {
            Swag.Add(1);
        }
    }
