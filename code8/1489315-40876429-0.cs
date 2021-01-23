    public void AddApplePie(string incredientA, string incredientB)
    {
        try
        {
            ...
        }
        catch(Exception ex)
        {
            ex.Data["IncredientA"] = incredientA;
            ex.Data.Add("IncredientB", incredientB);
            throw;
        }
    }
