    try
    {
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePendingContact", lastNameParameter);
    }
    catch (Exception ex)
    {
        if (ex.InnerException is SqlException) { throw ex.InnerException; }
        else { throw; }
    }
