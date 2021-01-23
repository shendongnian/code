    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void textBox_GotFocus(object sender, RoutedEventArgs e)
            {
                var postion = System.Windows.Forms.Cursor.Position;
                textBox.Text = string.Format($"{postion.X}, {postion.Y}");
            }
        }
    }
