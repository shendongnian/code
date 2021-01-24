    public partial class Window1 : Window
        {
        private string text;
        public Window1 ()
            {
            InitializeComponent();
            }
        private void button_Click (object sender, RoutedEventArgs e)
            {
            text = textBox.Text;
            MainWindow mainWindow = new MainWindow(text);
            mainWindow.Show();
            this.Close();
            }
        }
