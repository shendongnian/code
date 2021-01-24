    internal class CustomerViewModel : INotifyPropertyChanged
    {
        public CustomerViewModel()
        {
            _Customer = new Customer();
            // Subscribe to the PropertyChanged event
            _Customer.PropertyChanged += _Customer_PropertyChanged;
        }
        private void _Customer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check if Name changed, if yes, trigger the event so subscribers (view) can update.
            if (e.PropertyName == nameof(Customer.Name))
            {
                OnPropertyChanged(nameof(Name));
            }
        }
        private Customer _Customer;
        public string Name
        {
            get { return _Customer.Name; }
            set
            {
                _Customer.Name = value;
                OnPropertyChanged("Name");
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    } 
