    try
    {
        //put your copy code here
    }
    catch (StorageException ex)
    {
        //If the exception is 409, just skip the exception
        if (!ex.Message.Contains("409"))
        {
            throw ex;
        }
    }
