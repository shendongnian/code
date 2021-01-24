    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
