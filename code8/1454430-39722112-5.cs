    public T GetActiveDepartmentsQuotaOf<T>(Func<Department, T> exp)
        where T : IConvertible
    {
        return (T)Convert.ChangeType(Departments == null
                ? 0
                : Departments.Where(d => d.Status == 1)
                    .Sum(d => (int)Convert.ChangeType(exp(d), typeof(double)))
            , typeof(T));
    }
