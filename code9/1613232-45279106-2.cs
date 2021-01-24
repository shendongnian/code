    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var list = new List<MatrixType>
            {
                new MatrixType {Height = "233", Name = "A", Width = "133"},
                new MatrixType {Height = "333", Name = "B", Width = "233"},
                new MatrixType {Height = "433", Name = "C", Width = "333"}
            };
            Items = new ObservableCollection<MatrixType>(list);
        }
        private MatrixType _selectedItem;
        public MatrixType SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }
        public ObservableCollection<MatrixType> Items { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
