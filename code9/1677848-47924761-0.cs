    public IEnumerable<Employee> GetEmployee123()
    {
        try
        {
             var x = from n in db.Employees select n;
             return x;
        }
        catch (Exception ex)
        {   
             Business_Dll.Model.Errorhandlecls
                .ExceptionLogging.SendErrorToText(ex);
             return Enumerable.Empty<Employee>();
        }
    }
