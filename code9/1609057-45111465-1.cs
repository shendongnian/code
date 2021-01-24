    try
    {
        // here was the method I suspected of causing the problem
    }
    catch
    {
        throw new Exception(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
    }
