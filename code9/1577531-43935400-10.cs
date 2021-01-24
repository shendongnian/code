      public class TestVM : INotifyPropertyChanged
    {
        public TestVM()
        {
            ListOne = new ObservableCollection<string>()
            {
            "str1","str2","str3"
            };
            // command
            AddTypeCommand = new RelayCommand(OnAddExecute);
            DeleteTypeCommand = new RelayCommand(OnDeleteExecuted);
        }
        private void OnDeleteExecuted()
        {
            ListTwo.Clear();
        }
        private void OnAddExecute()
        {
            if (SelectedItem != null)
            {
                ListTwo.Add(SelectedItem);
            }
        }
        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<string> _listOne;
        public ObservableCollection<string> ListOne
        {
            get
            {
                return _listOne;
            }
            set
            {
                if (_listOne != value)
                {
                    _listOne = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> ListTwo { get; set; } = new ObservableCollection<string>();
        public RelayCommand AddTypeCommand { get; private set; }
        public RelayCommand DeleteTypeCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
