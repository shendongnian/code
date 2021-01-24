    partial class UserControl1 : UserControl, INotifyPropertyChanged
    {
        public ViewModelWrapper ViewModelWrapper { get; private set; }
        public UserControl1()
        {
            DataContextChanged += _OnDataContextChanged;
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModelWrapper = new ViewModelWrapper(DataContext);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ViewModelWrapper)));
        }
    }
