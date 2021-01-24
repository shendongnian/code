    private readonly ObservableCollection<Custmor> _loadDataBinding;
    public ViewModelADD(ObservableCollection<Custmor> loadDataBinding)
    {
        CustomerToAddObject = new Custmor();
        addCustomer1 = new RelayCommand(ADDFunction);
        _loadDataBinding = loadDataBinding;   
    }
    ...
    private void ADDFunction(object obj)
    {
        using (Test1Entities context = new Test1Entities())
        {
            context.Custmor.Add(customerToAddObject);
            context.SaveChanges();
        }
        _loadDataBinding.Add(customerToAddObject);
        ...
    }
