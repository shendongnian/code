    class ViewModel : INotifyProperrtyChanged
    {
        private ObservableCollection<CUSTOMER> _customers = new ObservableCollection<CUSTOMER>();
        public IList<CUSTOMER> Customers
        {
            get { return _customers; }
        }
        private CUSTOMER _selectedCustomer = null;
        public CUSTOMER SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
