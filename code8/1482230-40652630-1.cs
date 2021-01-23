    public class ItemViewModel :ViewModelBase
    {
        private ObservableCollection<ItemViewModel> _subItems = new ObservableCollection<ItemViewModel>();
        private string _name;
        private Status _status;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public Status Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
    
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                return _subItems;
            }
        }
    }
