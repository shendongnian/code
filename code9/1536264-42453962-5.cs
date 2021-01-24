    public partial class Window3 : Window
    {
        public ViewModel VM
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }        
        public Window1(ViewModel vm)
        {
            InitializeComponent();
            VM = vm;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.VM.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg")));
        }
    }
