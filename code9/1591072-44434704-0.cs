    public UnitOfWork UnitOfWorkItem
    {
        get
        {
            return ServiceLocator.Current.GetInstance<IUnitOfWork>();
        }
    }
