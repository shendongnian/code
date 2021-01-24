    public partial class MainWindow : Window
    { 
        public MainWindow()
        {  
            this.InitializeComponent();
            DataContext = new ViewModel(); 
        } 
    }
