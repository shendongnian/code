    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        int cont = 1;
        private void GridViewItems_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            txtScroll.Text = cont.ToString();
            cont += 1;
        }
    }
