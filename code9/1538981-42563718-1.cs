    public partial class PictureWindow : Window
    {
        public string imgsrc = string.Empty;
        public PictureWindow()
        {
            InitializeComponent();
        }
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pbImage.LoadAsync(imgsrc);
        }
    }
