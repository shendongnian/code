       public class TestVM : INotifyPropertyChanged
        {
            public TestVM()
            {
                ListOne = new ObservableCollection<string>()
                {
                "str1","str2","str3"
                };
    
                ListTwo = new ObservableCollection<string>();
    
                // command
                AddTypeCommand = new RelayCommand<string>(OnAddExecute);
                DeleteTypeCommand = new RelayCommand(OnDeleteExecuted);
            }
    
            private void OnDeleteExecuted()
            {
                ListTwo.Clear();
            }
    
            private void OnAddExecute(string obj)
            {
               if(SelectedItem != null)
                {
                    ListTwo.Add(obj);
                }
            }
    
            private string _selectedItem;
            public string SelectedItem
            {
                get { return _selectedItem; }
                set {
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
    
            private ObservableCollection<string> _listTwo;
            public ObservableCollection<string> ListTwo
            {
                get
                {
                    return _listTwo;
                }
                set
                {
                    if (_listTwo != value)
                    {
                        _listTwo = value;
                        OnPropertyChanged();
                    }
                }
            }
    
            public RelayCommand<string> AddTypeCommand { get; private set; }
            public RelayCommand DeleteTypeCommand { get; private set; }
    
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
        }
