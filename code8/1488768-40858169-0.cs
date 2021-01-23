    catch (DbEntityValidationException dbEx)
    {
        foreach (var validationErrors in dbEx.EntityValidationErrors)
        {
            foreach (var validationError in validationErrors.ValidationErrors)
            {
                Trace.TraceInformation("Property: {0} Error: {1}", 
                                        validationError.PropertyName, 
                                        validationError.ErrorMessage);
            }
        }
    }
