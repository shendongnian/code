    public BankViewModel(ICustomerRepository customerRepo)
       :this()
    {
        customerRepository = customerRepo;
    }
    public BankViewModel()
    {
        _canExecute = true;
    }
