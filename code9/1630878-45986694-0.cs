    // Message = "Must declare the scalar variable \"@OldCompany\"." - have tried with both the parameter1 and parameter1.Value, parameter2 and parameter2.Value
    public virtual int usp_TransferRecords(int oldCompany, int newCompany)
    {
        SqlParameter parameter1 = new SqlParameter("OldCompany", oldCompany);
        SqlParameter parameter2 = new SqlParameter("NewCompany", newCompany);
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreCommand("usp_CopyRecord @OldCompany, @NewCompany", parameter1, parameter2);
    }
