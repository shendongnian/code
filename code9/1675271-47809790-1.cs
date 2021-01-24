    private readonly Dictionary<Type, Type> _concreteImplementations = new Dictionary<Type, Type>();
    public Factory()
    {
        _concreteImplementations.Add(typeof(ICustomerService), typeof(CustomerService));
    }
    public TService GetService<TService>()
    {
        Type toInstantiate;
        if (_concreteImplementations.TryGetValue(typeof(TService), out toInstantiate))
        {
            object[] args = new object[] { (unitOfWork) };
            return (TService)(object)Activator.CreateInstance(toInstantiate, args);   
        }
        else
        {
            return null;
        }
    }
