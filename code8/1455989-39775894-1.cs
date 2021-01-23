    class ViewModel : INotifyPropertyChanged
        {
            private DateTimeOffset _displayValue;
            public DateTimeOffset? DisplayValue
            {
                get
                {
                    return _displayValue;
                }
                set
                {
                    if (value != null) _displayValue = value.Value;
                    OnPropertyChanged();
                }
            }
            public ViewModel()
            {
                DisplayValue = new DateTimeOffset(2016, 9, 29, 6, 39, 10, 3, new TimeSpan());
            }
            public event PropertyChangedEventHandler PropertyChanged;
           
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
 
