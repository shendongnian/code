        class ViewModel : IDataErrorInfo, INotifyPropertyChanged
        {
            decimal _price;
            public decimal Price
            {
                get => _price;
                set
                {
                    _price = value;
                    RaisePropertyChanged(nameof(Price));
                    RaisePropertyChanged("Item[]");
                }
            }
    
            // Implementation of IDataErrorInfo
            string IDataErrorInfo.Error
            {
                get { return null; }
            }
    
            public string this[string columnName]
            {
                get
                {
                    if (columnName == "Price")
                    {
                        // Validate property and return a string if there is an error
                        if (Price < 0)
                            return "Cannot be negative.";
                    }
                    
                    // If there's no error, null gets returned
                    return null;
                }
            }
    
            void RaisePropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
