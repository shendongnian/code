    public class MainViewModel : INotifyPropertyChanged
    {
        public RelayCommand DoSomethingCommand { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public MainViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>
            {
                new ItemViewModel { First = "eins", Second = "zwei" },
                new ItemViewModel { First = "drei", Second = "vier" },
                new ItemViewModel { First = "fünf", Second = "sechs" }
            };
    
            DoSomethingCommand = new RelayCommand(OnDoSomething);
        }
    
        private void OnDoSomething()
        {
            Items.First().First = "sieben";
        }
    
        ObservableCollection<ItemViewModel> _items;
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                return _items;
            }
    
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
    }
