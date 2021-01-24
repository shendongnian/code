    public partial class MainWindow : Window
        {
        public MainWindow ()
            {
            InitializeComponent();
            }
        public MainWindow (string text) : this()
        {
            label.Content = text;
        }
        private void button_Click (object sender, RoutedEventArgs e)
            {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
            }
        }
