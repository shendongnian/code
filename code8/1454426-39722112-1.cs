    public T GetActiveDepartmentsQuotaOf<T>(Func<Department, int> exp)
        where T : IConvertible
    {
        return (T)Convert.ChangeType(Departments == null
            ? 0 : Departments.Where(d => d.Status == 1).Sum(exp), typeof(T));
    }
