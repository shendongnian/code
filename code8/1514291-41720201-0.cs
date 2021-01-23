    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseDown += Window3_PreviewMouseDown;
            PreviewMouseUp += Window3_PreviewMouseUp;
        }
        DateTime mouseDown;
        private void Window3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseDown = DateTime.Now;
        }
        readonly TimeSpan interval = TimeSpan.FromSeconds(3);
        private void Window3_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (DateTime.Now.Subtract(mouseDown) > interval)
                MessageBox.Show("Mouse was held down for > 3 seconds!");
            mouseDown = DateTime.Now;
        }
    }
