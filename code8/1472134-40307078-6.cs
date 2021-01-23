    public static TRole GetInstance<TRole>() where TRole : Role, new()
    {
        return new TRole();
    }
    Employee T = GetInstance<Employee>();
