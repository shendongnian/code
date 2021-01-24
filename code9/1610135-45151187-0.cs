    StreamWriter Writer = null, Writer2 = null, Writer3 = null;
    try
    {
        // your existing code
    }
    catch
    {
        // Handle
    }
    finally
    {
        if (Writer != null)
            Writer.Close();
        if (Writer2 != null)
            Writer2.Close();
        if (Writer3 != null)
            Writer3.Close();
    }
