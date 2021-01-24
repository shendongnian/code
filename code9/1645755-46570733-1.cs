    using System.Windows;
    using System.Windows.Media.Effects;
    namespace WpfApp3
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
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                Grid.Effect = new BlurEffect();
                Splash.Visibility = Visibility.Visible;
                var dlg = new Window();
                dlg.ShowDialog();
                Splash.Visibility = Visibility.Collapsed;
                Grid.Effect = null;
            }
        }
    }
