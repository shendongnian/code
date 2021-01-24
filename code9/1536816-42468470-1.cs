    private const string KEY_PREFIX = "Employee_";
    private object syncLock = new object();
    // innerEmployeeRetriever and cache are populated through the constructor
    public Employee GetEmployee(int id)
    {
        string key = KEY_PREFIX + id.ToString();
        // Get the employee from the cache
        var employee = cache[key];
        if (employee == null)
        {
            lock (syncLock)
            {
                // Double-check that another thread didn't beat us
                // to populating the cache
                var employee = cache[key];
                if (employee == null)
                {
                    employee = innerEmployeeRetriever.GetEmployee(id);
                    cache[key] = employee;
                }
            }
        }
        return employee;
    }
