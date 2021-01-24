    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }
        private void txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                list1.Items.Add(txt.Text);
                txt.Text = string.Empty;
                popup.IsOpen = false;
            }
        }
    }
