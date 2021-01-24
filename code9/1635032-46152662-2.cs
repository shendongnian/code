    public static List<IndexRegistration> GetAll<T>() where T : AggregateRoot, New()
    {
        T instance = new T();
        return _register.FindAll(r => r.aggregateType == instance.GetType());
    }
