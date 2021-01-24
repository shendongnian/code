    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Object> Items { get; }
        public bool HasItems => Items.Count > 0;
        public MyViewModel()
        {
            Items = new ObservableCollection<object>();
            Items.CollectionChanged += (s, e) => OnPropertyChanged(nameof(HasItems));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
