    public partial class MainWindow : Window
    {
        private WicBitmapSource _bmp;
        public MainWindow()
        {
            InitializeComponent();
            _bmp = new WicBitmapSource(@"c:\path\killroy_was_here.png");
            MyImage.Source = _bmp;
        }
        protected override void OnClosed(EventArgs e)
        {
            _bmp.Dispose();
        }
    }
