    public class ProductModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Item[]");
            }
        }
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
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
