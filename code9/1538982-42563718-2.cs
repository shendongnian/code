    public partial class MainWindow : Window
    {
        PictureWindow window;
    
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        window = new PictureWindow();
        window.imgsrc = textBox1.Text.Trim(); //Here you update your "Source" for your image.
        window.Show();
    }
