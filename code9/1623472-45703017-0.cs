    public partial class MainWindow : Window
    {
        public ViewModelBase vm;
        public MainWindow()
        {
            vm = (ViewModelBase)this.DataContext;
            InitializeComponent();
        }
