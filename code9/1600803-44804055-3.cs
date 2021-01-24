    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                ViewModel vm = new ViewModel();
                this.DataContext = vm;
        }
