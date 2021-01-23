    try 
    {
        using (Streamwriter sw = new StreamWriter(path, true) 
        {
            sw.WriteLine(log);
        }
    }
    catch (Exception ex)
    {
        // Log exception using System.Diagnostics.EventLog
    }
