    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            CalcObservable = DatabaseQueries.ShiftInputSourceObserv(SelectedEmployee.Key, DateFilter);
            MyDataGrid.SetBinding(ComboBox.ItemsSourceProperty, new Binding(nameof(CalcObservable)) { Source = this });
        }
        private ObservableCollection<CalcTable> _calcObservable = new ObservableCollection<CalcTable>();
        public ObservableCollection<CalcTable> CalcObservable
        {
            get { return _calcObservable; }
            set { _calcObservable = value; OnPropertyChanged(nameof(CalcObservable)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
