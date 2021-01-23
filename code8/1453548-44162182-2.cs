    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;
    
    namespace DialogTouchTest
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                ConfirmStudentWindow confirmWindow = new ConfirmStudentWindow();
                confirmWindow.Confirm += OnConfirm;
    
                // This window makes everything behind the dialog window a grey tint, which makes the dialog more prominent
                var darkwindow = new Window()
                {
                    Background = Brushes.Black,
                    Opacity = 0.4,
                    AllowsTransparency = true,
                    WindowStyle = WindowStyle.None,
                    WindowState = WindowState.Maximized,
                    Topmost = true,
                    Effect = new BlurEffect()
                };
                darkwindow.Show(); // Show grey background tint
                confirmWindow.ShowDialog(); // Stops main UI thread
                darkwindow.Close();
            }
    
            private void OnConfirm()
            {
    
            }
        }
    }
