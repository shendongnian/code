    public partial class MyWindow : Window
    {
        public MyWindow()
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
