    public T GetActiveDepartmentsQuotaOf<T>(Func<Department, double> exp)
        where T : IConvertible
    {
        return (T)Convert.ChangeType(Departments == null
            ? 0 : Departments.Where(d => d.Status == 1).Sum(exp), typeof(T));
    }
