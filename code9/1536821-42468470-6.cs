    private object syncLock = new object();
    // innerEmployeeRetriever and cache are populated through the constructor
    public Employee GetEmployeeList()
    {
        string key = "GetEmployeeList";
        // Get the employee from the cache
        var employees = cache[key];
        if (employees == null)
        {
            lock (syncLock)
            {
                // Double-check that another thread didn't beat us
                // to populating the cache
                var employees = cache[key];
                if (employees == null)
                {
                    employees = innerEmployeeRetriever.GetEmployeeList();
                    cache[key] = employees;
                }
            }
        }
        return employees;
    }
    
