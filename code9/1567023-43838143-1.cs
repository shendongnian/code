    public class ListViewBindingViewModel : INotifyPropertyChanged
    {
        private Tuple<string,int> _selectedValue;
    
        public ObservableCollection<Tuple<string,int>> Values { get; }
    
        public Tuple<string, int> SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                _selectedValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedValue)));
            }
        }
    
        public ListViewBindingViewModel()
        {
            Values = new ObservableCollection<Tuple<string, int>> {Tuple.Create("Dog", 3), Tuple.Create("Cat", 5), Tuple.Create("Rat",1)};
        }
    
    }
