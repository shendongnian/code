    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            this.Loaded += (s,e) => comboBox.Focus();
         }
    }
