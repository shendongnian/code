    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Strings { get; set; }
    
        public ICommand AddAnotherStringCommand { get; set; }
    
        string _selectedItem;
        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
    
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(this.SelectedItem));
            }
        }
    
        public int counter { get; set; } = 1;
    
        public ViewModel()
        {
            // RelayCommand from: https://stackoverflow.com/questions/22285866/why-relaycommand
            this.AddAnotherStringCommand = new RelayCommand<object>(AddAnotherString);
            this.Strings = new ObservableCollection<string>();
            this.Strings.Add("First item");
        }
    
        private void AddAnotherString(object notUsed = null)
        {
            this.Strings.Add(counter.ToString());
            counter++;
            this.SelectedItem = counter.ToString();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
