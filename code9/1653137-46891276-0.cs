    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => Keyboard.Focus(tb);
	}
    }
