    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tabContainer.Items.Add(new MyUserControl());
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            tabContainer.Items.Remove(button.Tag);
        }
    }
