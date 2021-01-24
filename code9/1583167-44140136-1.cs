    private readonly Window _window;
    private readonly ObservableCollection<Custmor> _loadDataBinding;
    public ViewModelADD(Window window, ObservableCollection<Custmor> loadDataBinding)
    {
        CustomerToAddObject = new Custmor();
        addCustomer1 = new RelayCommand(ADDFunction);
        _window = window;
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
        _window.Close();
        ...
    }
