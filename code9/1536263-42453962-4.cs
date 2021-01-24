    public partial class MainWindow : Window
        {
            public ViewModel VM
            {
                get { return this.DataContext as ViewModel; }
                set { this.DataContext = value; }
            }        
    
            public MainWindow()
            {
                this.VM = new ViewModel();
                InitializeComponent();
    
                this.VM.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg")));
            }        
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                Window3 win = new Window3(VM);
                win.Owner = this;
                win.Show();
            }
        }
