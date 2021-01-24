    public MainVM()
    {
        Customer = new CustomerVM();
        Supplier = new SupplierVM();
    }
    public CustomerVM Customer {
        get { return _customerVM; }
        private set { _customerVM = value; }
    }
    public SupplierVM Supplier {
        get { return _supplierVM; }
        private set { _supplierVM = value; }
    }
    public INotifyPropertyChanged _selectedChild;
    public INotifyPropertyChanged SelectedChild {
        get { return _selectedChild; }
        set {
            if (value != _selectedChild) {
                _selectedChild = value;
                //  I don't know how you raise PropertyChanged; if it doesn't look 
                //  like this, let me know. 
                OnPropertyChanged();
            }
        }
    }
    public void Navigate()
    {        
        SelectedChild = Customer;
    }
