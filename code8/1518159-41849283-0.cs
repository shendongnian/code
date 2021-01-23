    namespace WpfCSharpSandbox
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                WidenObject(150, TimeSpan.FromSeconds(1));
            }
    
            private void WidenObject(int newWidth, TimeSpan duration)
            {
                DoubleAnimation animation = new DoubleAnimation(newWidth, duration);
                rctMovingObject.BeginAnimation(Rectangle.WidthProperty, animation);
            }
        }
    }
