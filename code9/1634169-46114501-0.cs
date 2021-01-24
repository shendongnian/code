    public IEnumerable<Employee> GetData()
    {
        try
        {
            var x = from n in db.Employee
                    select n;
            return x.ToList();
        }
        catch (SqlException ex)
        {
            Logger.Error(ex.Message, ex);
            throw;
        }
    }
