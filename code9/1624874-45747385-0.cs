    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Open Window 2
        private void buttonWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2(); // No need to give a reference to the child window anymore
            window2.setClickHandler((obj, e) => {
                textBlockMessage.Text = "Hello, world!"; // Direct access to the textblock.
            });
            window2.Left = Math.Max(this.Left - window2.Width, 0);
            window2.Top = Math.Max(this.Top - 0, 0);
            window2.ShowDialog();
        }
    }
