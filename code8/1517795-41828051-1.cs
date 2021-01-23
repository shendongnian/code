    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
            Something st = new Something();
            this.DataContext = st;
        }
 
    }
