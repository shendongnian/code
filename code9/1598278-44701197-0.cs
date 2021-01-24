    T objectOut = default(T);
    if (!System.IO.File.Exists(filepath)) return objectOut;
    
    try
    {
        // ...
    }
    catch (Exception ex)
    {
        //Log exception here
        logger.Error("Error Deserializing: " + ex.Message);
    }
    return objectOut;
