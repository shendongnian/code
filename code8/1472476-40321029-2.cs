    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.Navigate(new PlayPage());
            SwagMeasurer.Text = Convert.ToString(Swag.Get());
            Swag.OnAddition += Swag_Addition;
            Swag.OnSubtraction += Swag_OnSubtraction;
            Swag.OnUpdate += Swag_OnUpdate;
        }
        private void Swag_OnUpdate(SwagEventArgs e)
        {
            SwagMeasurer.Text = Convert.ToString(Swag.Get());
        }
        private void Swag_OnSubtraction(SwagEventArgs e)
        {
            LastMode.Text = "That's a negative";
        }
        private void Swag_Addition(SwagEventArgs e)
        {
            LastMode.Text = "That's a positive";
        }
    }
