    if (processingExcption is System.Data.Entity.Validation.DbEntityValidationException)
    {
        exceptionIsHandled = true;
        var entityEx = (System.Data.Entity.Validation.DbEntityValidationException)processingExcption;
        foreach (var item in entityEx.EntityValidationErrors)
        {
            foreach (var err in item.ValidationErrors)
                returnVal.Invalidate(SystemMessageCategory.Error, err.ErrorMessage);
        }
    }
    else if (processingExcption is System.Data.SqlClient.SqlException && ((System.Data.SqlClient.SqlException)processingExcption).Number == -2)//-2 = Timeout Exception
    {
        exceptionIsHandled = true;
        returnVal.Invalidate(SystemMessageCategory.Error, "Database failed to respond in the allotted time. Please retry your action or contact your system administrator for assistance.", 
            messageCode: Architecture.SystemMessage.SystemMessageCode.DBTimeout);
    }
