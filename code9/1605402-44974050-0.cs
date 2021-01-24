    public class CustomerViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customerList = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> CustomerList {
            get { return _customerList; }
            set {
                if (_customerList != value) {
                    _customerList != value;
                    //  Member of ViewModelBase that raises PropertyChanged
                    OnPropertyChanged(nameof(CustomerList));
                }
            }
        }
